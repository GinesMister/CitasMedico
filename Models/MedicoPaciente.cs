using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CitasMedico.Models
{
    public class MedicoPaciente
    {
        [Key]
        public int IdMedico { get; set; }
        [Key]
        public int IdPaciente { get; set; }
        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }
    }
}
