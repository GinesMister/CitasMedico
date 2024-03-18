using CitasMedico.Data;
using CitasMedico.Models;
using Microsoft.EntityFrameworkCore;

namespace CitasMedico.Repository
{
    public class CitaRepository<T> : GenericRepository<T> where T : Cita
    {
        private readonly DataContext _context;

        public CitaRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public new IEnumerable<Cita> GetAll()
        {
            return _context.Cita.Include(m => m.Diagnostico).ToList();
        }

        public new Cita? GetById(int id)
        {
            return _context.Cita.Include(m => m.Diagnostico).FirstOrDefault(m => m.Id == id);
        }
    }
}
