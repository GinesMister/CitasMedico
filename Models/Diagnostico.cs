using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitasMedico.Models
{
    public class Diagnostico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ValoracionEspecialista { get; set; }
        public string Enfermedad { get; set; }

        public virtual Cita Cita { get; set; }
    }
}
