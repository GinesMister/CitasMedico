using Microsoft.EntityFrameworkCore.Update.Internal;

namespace CitasMedico.DTOs
{
    public class PacienteDTO : UsuarioDTO
    {
        public string NSS { get; set; }
        public string NumTarjeta { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public virtual ICollection<CitaDTO> Citas { get; set; }
        public virtual ICollection<MedicoDTO> Medicos { get; set; }
    }
}
