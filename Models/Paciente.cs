using System.IO.Pipes;

namespace CitasMedico.Models
{
    public class Paciente : Usuario
    {
        public string NSS { get; set; }
        public string NumTarjeta { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        public ICollection<Cita> Citas { get; set; } = new List<Cita>();
        public ICollection<MedicoPaciente> Medicos { get; set; } = new List<MedicoPaciente>();
    }
}
