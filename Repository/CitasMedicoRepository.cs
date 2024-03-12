using CitasMedico.Data;
using Microsoft.EntityFrameworkCore;

namespace CitasMedico.Repository
{
    public interface ICitasMedicoRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }

    public class CitasMedicoRepository<T> : ICitasMedicoRepository<T> where T : class
    {
        private readonly DataContext _context;

        public CitasMedicoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);
        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();
        public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);
        public async Task UpdateAsync(T entity) => await Task.Run(() => _context.Set<T>().Update(entity));
        public async Task DeleteAsync(T entity) => await Task.Run(() => _context.Set<T>().Remove(entity));
    }
}
