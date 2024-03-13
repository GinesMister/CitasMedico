using CitasMedico.Models;

namespace CitasMedico.DTOs
{
    public class MedicoDTO : UsuarioDTO
    {
        public string NumColegiado { get; set; }
        public virtual ICollection<CitaDTO> Citas { get; set; }
    }
}
