using CitasMedico.Data;
using CitasMedico.Models;
using Microsoft.EntityFrameworkCore;

namespace CitasMedico.Repository
{
    public class PacienteRepository<T> : GenericRepository<T> where T : Paciente
    {
        private readonly DataContext _context;

        public PacienteRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public new IEnumerable<Paciente> GetAll()
        {
            return _context.Paciente.Include(m => m.Citas).ToList();
        }

        public new Paciente? GetById(int id)
        {
            return _context.Paciente.Include(m => m.Citas).FirstOrDefault(m => m.Id == id);
        }
    }
}
