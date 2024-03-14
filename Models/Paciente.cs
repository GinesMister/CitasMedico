
namespace CitasMedico.Models
{
    public class Paciente : Usuario
    {
        public string NSS { get; set; }
        public string NumTarjeta { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<Cita> Citas { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
    }
}