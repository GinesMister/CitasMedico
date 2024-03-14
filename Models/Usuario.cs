using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitasMedico.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string Nombre{ get; set; }
        public string Apellidos{ get; set; }
        public string NombreUsuario { get; set; }
        public string Clave{ get; set; }
    }
}
