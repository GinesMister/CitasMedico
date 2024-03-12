using System.ComponentModel.DataAnnotations;

namespace CitasMedico.Models
{
    public class Cita
    {
        [Key]
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string MotivoCita { get; set; }

        public Diagnostico Diagnostico { get; set; }
        public int IdMedico { get; set; }
        public int IdPaciente { get; set; }
        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }
    }
}
