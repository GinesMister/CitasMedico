namespace CitasMedico.Models
{
    public class Medico : Usuario
    {
        public string NumColegiado { get; set; }

        public ICollection<Cita> Citas { get; set; }
        public ICollection<MedicoPaciente> pacientes { get; set; } = new List<MedicoPaciente>();
    }
}
