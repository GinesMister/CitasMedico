namespace CitasMedico.Models
{
    public class Diagnostico
    {
        public int Id { get; set; }
        public string ValoracionEspecialista { get; set; }
        public string Enfermedad {  get; set; }

        public Cita Cita { get; set; }
    }
}
