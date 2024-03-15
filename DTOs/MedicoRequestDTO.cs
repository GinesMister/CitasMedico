namespace CitasMedico.DTOs
{
    public class MedicoRequestDTO : UsuarioRequestDTO
    {
        public string NumColegiado { get; set; }
        public IEnumerable<int>? IdsPaciente {  get; set; }
    }
}
