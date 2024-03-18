using CitasMedico.Data;
using CitasMedico.Models;
using Microsoft.EntityFrameworkCore;

namespace CitasMedico.Repository
{
    public class MedicoRepository<T> : GenericRepository<T> where T : Medico
    {
        private readonly DataContext _context;

        public MedicoRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public new IEnumerable<Medico> GetAll()
        {
            return _context.Medico.Include(m => m.Pacientes)
                //.Include(m => m.Citas)
                .ToList();
        }

        public new Medico? GetById(int id)
        {
            return _context.Medico.Include(m => m.Pacientes).FirstOrDefault(m => m.Id == id);
        }
    }
}
