using CitasMedico.Data;
using CitasMedico.Models;

namespace CitasMedico.Repository
{
    public interface IUnitOfWork
    {
        CitasMedicoRepository<Medico> Medicos { get; }
        CitasMedicoRepository<Cita> Citas { get; }
        CitasMedicoRepository<Diagnostico> Diagnosticos { get; }
        CitasMedicoRepository<Paciente> Pacientes { get; }
        CitasMedicoRepository<Usuario> Usuarios { get; }
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

        public CitasMedicoRepository<Medico> Medicos { get; }
        public CitasMedicoRepository<Cita> Citas { get; }
        public CitasMedicoRepository<Diagnostico> Diagnosticos { get; }
        public CitasMedicoRepository<Paciente> Pacientes{ get; }
        public CitasMedicoRepository<Usuario> Usuarios { get; }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
