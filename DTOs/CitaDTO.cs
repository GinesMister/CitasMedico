using CitasMedico.Models;

namespace CitasMedico.DTOs
{
    public class CitaDTO
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string MotivoCita { get; set; }

        public int IdDiagnostico { get; set; }
        public int IdMedico { get; set; }
        public int IdPaciente { get; set; }
    }
}
