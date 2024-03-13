using CitasMedico.Data;
using Microsoft.EntityFrameworkCore;

namespace CitasMedico.Repository
{

    public class CitasMedicoRepository<T> : ICitasMedicoRepository<T> where T : class
    {
        private readonly DataContext _context;

        public CitasMedicoRepository(DataContext context)
        {
            _context = context;
        }

        public T Add(T entity)
        {
            return _context.Add(entity).Entity;
        }

        public T Delete(T entity)
        {
            return _context.Remove(entity).Entity;
        }

        public bool Exist(int id)
        {
            return _context.Set<T>().Any(e => e.GetType().GetProperty("Id").GetValue(e) as int? == id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T? GetById(int id)
        {
            if (!Exist(id))
                return null;

            return _context.Set<T>().Find(id);
        }

        public T Update(T entity)
        {
            return _context.Update(entity).Entity;
        }
    }
}