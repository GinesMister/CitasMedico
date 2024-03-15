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
            CreateMap<CitaDTO, Cita>();

            CreateMap<Diagnostico, DiagnosticoDTO>();
            CreateMap<DiagnosticoDTO, Diagnostico>();
            
            CreateMap<Medico, MedicoDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                //.ForMember(dest => dest.Citas, opt => opt.MapFrom(src => src.Citas))
                //.ForMember(dest => dest.Pacientes, opt => opt.MapFrom(src => src.Pacientes))
                ;
            CreateMap<MedicoDTO, Medico>();
            CreateMap<MedicoDTO, MedicoRequestDTO>();
            CreateMap<MedicoRequestDTO, MedicoDTO>();
            CreateMap<Medico, MedicoRequestDTO>();
            CreateMap<MedicoRequestDTO, Medico>();

            CreateMap<Paciente, PacienteDTO>();
            CreateMap<PacienteDTO, Paciente>();
            CreateMap<PacienteDTO, PacienteRequestDTO>();
            CreateMap<PacienteRequestDTO, PacienteDTO>();
            CreateMap<PacienteRequestDTO, Paciente>();
            CreateMap<Paciente, PacienteRequestDTO>();
        }
    }
}