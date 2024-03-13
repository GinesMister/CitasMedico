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
            Citas = new CitasMedicoRepository<Cita>(_context);
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

        public int SaveChanges() => _context.SaveChanges();
    }
}
