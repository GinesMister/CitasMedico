using CitasMedico.DTOs;

namespace CitasMedico.Models
{
    public class Medico : Usuario
    {
        public string NumColegiado { get; set; }

        public virtual ICollection<Cita> Citas { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }

        public void Update(MedicoRequestDTO medico)
        {
            Clave = medico.Clave;
            Nombre = medico.Nombre;
            Apellidos = medico.Apellidos;
            NombreUsuario = medico.NombreUsuario;
            NumColegiado = medico.NumColegiado;
        }
    }
}
