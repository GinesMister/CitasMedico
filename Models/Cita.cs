using AutoMapper;
using CitasMedico.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitasMedico.Models
{
    public class Cita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string MotivoCita { get; set; }

        public Diagnostico Diagnostico { get; set; }

        public int IdMedico { get; set; }
        public int IdPaciente { get; set; }
        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }

        public void Update(IMapper _mapper, CitaDTO cita)
        {
            FechaHora = cita.FechaHora;
            MotivoCita = cita.MotivoCita;
            Diagnostico = _mapper.Map<Diagnostico>(cita.Diagnostico);
            IdMedico = cita.IdMedico;
            IdPaciente = cita.IdPaciente;
        }
    }
}
