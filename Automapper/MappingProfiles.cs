using AutoMapper;
using Azure.Core;
using CitasMedico.DTOs;
using CitasMedico.Models;

namespace CitasMedico.Automapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Cita, CitaDTO>();
            CreateMap<Diagnostico, DiagnosticoDTO>();
            CreateMap<Medico, MedicoDTO>();
            CreateMap<Paciente, PacienteDTO>();
        }
    }
}