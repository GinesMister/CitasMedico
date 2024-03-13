using AutoMapper;
using CitasMedico.Automapper;
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
            return _mapper.Map<Cita, CitaDTO>(_unitOfWork.Citas.GetById(id));
        }

        public CitaDTO CreateCita(CitaDTO cita)
        {
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
                _unitOfWork.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ErrorType.UnexpectedError, "Ha ocurrido un error inesperado", ex.InnerException);
            }
        }

        public async Task<CitaDTO> UpdateCita(int id, CitaDTO cita)
        {
            if (cita.Id == id)
                throw new ServiceException(ErrorType.BadRequest, "El ID proporcionado y el de la cita no es el mismo");
            Cita? Cita = _unitOfWork.Citas.GetById(cita.Id);
            if (cita == null)
                throw new ServiceException(ErrorType.NotFound, "No hay una cita con ese ID");
            try
            {
                return _mapper.Map<Cita, CitaDTO>(_unitOfWork.Citas.Update(Cita));
            }
            catch (Exception ex)
            {
                throw new ServiceException(ErrorType.UnexpectedError, "Error inesperado en el proceso de actualización", ex.InnerException);
            }
        }

    }
}
