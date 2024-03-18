using AutoMapper;
using CitasMedico.DTOs;
using CitasMedico.Exceptions;
using CitasMedico.Models;
using CitasMedico.Repository;

namespace CitasMedico.Services
{
    
    public class CitaService
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;

        public CitaService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<CitaDTO> GetAllCitas()
        {
            return _mapper.Map<IEnumerable<CitaDTO>>(_unitOfWork.Citas.GetAll());
        }

        public CitaDTO GetCitaById(int id)
        {
            if (!_unitOfWork.Citas.Exist(id))
                throw new ServiceException(ErrorType.NotFound, "No existe una cita con ese Id");
            return _mapper.Map<CitaDTO>(_unitOfWork.Citas.GetById(id));
        }

        public CitaDTO CreateCita(CitaDTO cita)
        {
            if (!_unitOfWork.Medicos.Exist(cita.IdMedico))
                throw new ServiceException(ErrorType.NotFound, "El ID del médico no existe");
            if (!_unitOfWork.Pacientes.Exist(cita.IdPaciente))
                throw new ServiceException(ErrorType.NotFound, "El ID del paciente no existe");

            // Unión de médico y paciente
            Medico Medico = _unitOfWork.Medicos.GetById(cita.IdMedico);
            Paciente Paciente = _unitOfWork.Pacientes.GetById(cita.IdPaciente);
            Medico.Pacientes.Add(Paciente);
            _unitOfWork.Medicos.Update(Medico);
            try
            {
                var result = _mapper.Map<CitaDTO>(_unitOfWork.Citas.Add(_mapper.Map<Cita>(cita)));
                _unitOfWork.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ErrorType.UnexpectedError, "Ha ocurrido un error inesperado", ex.InnerException);
            }

        }

        public CitaDTO DeleteCitaById(int id)
        {
            if (!_unitOfWork.Citas.Exist(id))
                throw new ServiceException(ErrorType.NotFound);
            try
            {
                var result = _mapper.Map<CitaDTO>(_unitOfWork.Citas.Delete(_unitOfWork.Citas.GetById(id)));
                _unitOfWork.Diagnosticos.Delete(_unitOfWork.Diagnosticos.GetById((int) result.Diagnostico.Id));
                _unitOfWork.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ErrorType.UnexpectedError, "Ha ocurrido un error inesperado", ex.InnerException);
            }
        }

        public CitaDTO UpdateCita(int id, CitaDTO cita)
        {
            if (cita.Id == null)
               throw new ServiceException(ErrorType.BadRequest, "No se ha proporcionado un ID en la cita");
            if (cita.Id != id)
                throw new ServiceException(ErrorType.BadRequest, "El ID proporcionado y el de la cita no es el mismo");
            Cita? Cita = _unitOfWork.Citas.GetById(id);
            if (cita == null)
                throw new ServiceException(ErrorType.NotFound, "No hay una cita con ese ID");
            Cita.Update(cita);

            // Update de Diagnostico
            if (Cita.Diagnostico.Id != cita.Diagnostico.Id)
                throw new ServiceException(ErrorType.BadRequest, "No se ha proporcionado el ID del diagnóstico correctamente");
            Diagnostico Diagnostico = _unitOfWork.Diagnosticos.GetById((int) cita.Diagnostico.Id);
            Diagnostico.Update(cita.Diagnostico);

            try
            {
                _unitOfWork.Citas.Update(Cita);
                _unitOfWork.Diagnosticos.Update(Diagnostico);
                _unitOfWork.SaveChanges();
                return _mapper.Map<CitaDTO>(cita);
            }
            catch (Exception ex)
            {
                throw new ServiceException(ErrorType.UnexpectedError, "Error inesperado en el proceso de actualización", ex.InnerException);
            }
        }

    }
}
