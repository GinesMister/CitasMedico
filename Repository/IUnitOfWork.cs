using CitasMedico.Data;
using CitasMedico.Models;

namespace CitasMedico.Repository
{
    public interface IUnitOfWork
    {
        ICitasMedicoRepository<Medico> Medicos { get; }
        ICitasMedicoRepository<Cita> Citas { get; }
        ICitasMedicoRepository<Diagnostico> Diagnosticos { get; }
        ICitasMedicoRepository<Paciente> Pacientes { get; }
        ICitasMedicoRepository<Usuario> Usuarios { get; }
        Task<int> SaveChangesAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Medicos = new CitasMedicoRepository<Medico>(_context);
            Diagnosticos = new CitasMedicoRepository<Diagnostico>(_context);
            Pacientes = new CitasMedicoRepository<Paciente>(_context);
            Usuarios = new CitasMedicoRepository<Usuario>(_context);
        }

        public ICitasMedicoRepository<Medico> Medicos { get; }
        public ICitasMedicoRepository<Cita> Citas { get; }
        public ICitasMedicoRepository<Diagnostico> Diagnosticos { get; }
        public ICitasMedicoRepository<Paciente> Pacientes{ get; }
        public ICitasMedicoRepository<Usuario> Usuarios { get; }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
