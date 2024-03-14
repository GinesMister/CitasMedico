namespace CitasMedico.Models
{
    public class Medico : Usuario
    {
        public string NumColegiado { get; set; }

        public virtual ICollection<Cita> Citas { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
