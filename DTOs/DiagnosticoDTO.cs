using CitasMedico.Models;

namespace CitasMedico.DTOs
{
    public class DiagnosticoDTO
    {
        public int Id { get; set; }
        public string ValoracionEspecialista { get; set; }
        public string Enfermedad { get; set; }

        public CitaDTO Cita { get; set; }
    }
}
