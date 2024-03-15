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
        }

        public new IEnumerable<T> GetAll()
        {
            return (IEnumerable<T>)_context.Medico.Include(m => m.Pacientes).AsEnumerable();
        }
    }
}
