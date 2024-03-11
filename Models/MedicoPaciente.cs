namespace CitasMedico.Models
{
    public class MedicoPaciente
    {
        public int IdMedico { get; set; }
        public int IdPaciente { get; set; }
        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }
    }
}
