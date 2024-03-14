
using CitasMedico.DTOs;

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

        public void Update(PacienteRequestDTO paciente)
        {
            Clave = paciente.Clave;
            Nombre = paciente.Nombre;
            Apellidos = paciente.Apellidos;
            NombreUsuario = paciente.NombreUsuario;
            NSS = paciente.NSS;
            NumTarjeta = paciente.NumTarjeta;
            Telefono = paciente.Telefono;
            Direccion = paciente.Direccion;
        }
    }
}