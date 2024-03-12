using CitasMedico.Models;

namespace CitasMedico.DTOs
{
    public class CitaDTO
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string MotivoCita { get; set; }

        public Diagnostico Diagnostico { get; set; }
        public Medico Medico { get; set; }
        public PacienteDTO Paciente { get; set; }
    }
}
