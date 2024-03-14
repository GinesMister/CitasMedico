using AutoMapper;
using CitasMedico.DTOs;
using CitasMedico.Exceptions;
using CitasMedico.Models;
using CitasMedico.Repository;

namespace CitasMedico.Services
{
    public class PacienteService 
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;

        public PacienteService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<PacienteDTO> GetAllPacientes()
        {
            return _mapper.Map<IEnumerable<PacienteDTO>>(_unitOfWork.Pacientes.GetAll());
        }

        public PacienteDTO GetPacienteById(int id)
        {
            if (!_unitOfWork.Medicos.Exist(id))
                throw new ServiceException(ErrorType.NotFound, "No existe un paciente con ese Id");
            return _mapper.Map<PacienteDTO>(_unitOfWork.Pacientes.GetById(id));
        }

        public PacienteDTO CreatePaciente(PacienteRequestDTO paciente)
        {
            try
            {
                var result = _mapper.Map<PacienteDTO>(_unitOfWork.Pacientes.Add(_mapper.Map<PacienteRequestDTO, Paciente>(paciente)));
                _unitOfWork.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ErrorType.UnexpectedError, "Ha ocurrido un error inesperado", ex.InnerException);
            }

        }

        public PacienteDTO DeletePacienteById(int id)
        {
            if (!_unitOfWork.Pacientes.Exist(id))
                throw new ServiceException(ErrorType.NotFound);
            try
            {
                var result = _mapper.Map<PacienteDTO>(_unitOfWork.Pacientes.Delete(_unitOfWork.Pacientes.GetById(id)));
                _unitOfWork.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ErrorType.UnexpectedError, "Ha ocurrido un error inesperado", ex.InnerException);
            }
        }

        public PacienteDTO UpdatePaciente(int id, PacienteRequestDTO paciente)
        {
            Paciente? Paciente = _unitOfWork.Pacientes.GetById(id);
            if (Paciente == null)
                throw new ServiceException(ErrorType.NotFound, "No hay un paciente con ese ID");
            try
            {
                Paciente.Update(paciente);
                _unitOfWork.Pacientes.Update(_mapper.Map<Paciente>(Paciente));

                _unitOfWork.SaveChanges();
                return _mapper.Map<PacienteDTO>(Paciente);
            }
            catch (ServiceException ex)
            {
                throw new ServiceException(ErrorType.UnexpectedError, "Error inesperado en el proceso de actualización", ex.InnerException);
            }
        }
    }
}
