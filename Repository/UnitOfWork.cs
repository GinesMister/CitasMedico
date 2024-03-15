using CitasMedico.Data;
using CitasMedico.Interfaces;
using CitasMedico.Models;

namespace CitasMedico.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Citas = new GenericRepository<Cita>(_context);
            Medicos = new GenericRepository<Medico>(_context);
            Diagnosticos = new GenericRepository<Diagnostico>(_context);
            Pacientes = new GenericRepository<Paciente>(_context);
            Usuarios = new GenericRepository<Usuario>(_context);
        }

        public GenericRepository<Medico> Medicos { get; }
        public GenericRepository<Cita> Citas { get; }
        public GenericRepository<Diagnostico> Diagnosticos { get; }
        public GenericRepository<Paciente> Pacientes{ get; }
        public GenericRepository<Usuario> Usuarios { get; }

        public int SaveChanges() => _context.SaveChanges();
    }
}
