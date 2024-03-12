using AutoMapper;
using CitasMedico.Automapper;
using CitasMedico.DTOs;
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

        public async Task<IEnumerable<CitaDTO>> GetAllCitas()
        {
            var result = _mapper.Map<IEnumerable<CitaDTO>>(_unitOfWork.Citas.GetAllAsync());
            await _unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<CitaDTO> GetCitaById(int id)
        {
            var result = _mapper.Map<CitaDTO>(_unitOfWork.Citas.GetByIdAsync(id));
            await _unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<CitaDTO> CreateCita(CitaDTO cita)
        {
            var result = _mapper.Map<CitaDTO>(_unitOfWork.Citas.AddAsync(_mapper.Map<Cita>(cita)));

            await _unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<CitaDTO> DeleteCitaById(int id)
        {
            Cita cita = await _unitOfWork.Citas.GetByIdAsync(id);
            var result = _mapper.Map<CitaDTO>(_unitOfWork.Citas.DeleteAsync(cita));
            await _unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<CitaDTO> UpdateCita(CitaDTO cita)
        {
            var result = _mapper.Map<CitaDTO>(_unitOfWork.Citas.UpdateAsync(_unitOfWork.Citas.GetByIdAsync(cita.Id).Result));
            await _unitOfWork.SaveChangesAsync();
            return result;
        }

    }
}
