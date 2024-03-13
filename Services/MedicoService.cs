using AutoMapper;
using CitasMedico.DTOs;
using CitasMedico.Exceptions;
using CitasMedico.Models;
using CitasMedico.Repository;

namespace CitasMedico.Services
{
    public class MedicoService
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;

        public MedicoService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<MedicoDTO> GetAllMedicos()
        {
            return _mapper.Map<IEnumerable<MedicoDTO>>(_unitOfWork.Medicos.GetAll());
        }

        public MedicoDTO GetMedicoById(int id)
        {
            if (!_unitOfWork.Medicos.Exist(id))
                throw new ServiceException(ErrorType.NotFound, "No existe un médico con ese Id");
            return _mapper.Map<MedicoDTO>(_unitOfWork.Medicos.GetById(id));
        }

        public MedicoDTO CreateMedico(MedicoDTO medico)
        {
            try
            {
                var result = _mapper.Map<MedicoDTO>(_unitOfWork.Medicos.Add(_mapper.Map<Medico>(medico)));
                _unitOfWork.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ErrorType.UnexpectedError, "Ha ocurrido un error inesperado", ex.InnerException);
            }

        }
    }
}
