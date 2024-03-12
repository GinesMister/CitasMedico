namespace CitasMedico.DTOs
{
    public class PacienteDTO : UsuarioDTO
    {
        public string NSS { get; set; }
        public string NumTarjeta { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
    }
}
