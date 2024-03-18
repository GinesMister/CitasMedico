using CitasMedico.Data;
using CitasMedico.Interfaces;
using CitasMedico.Models;

namespace CitasMedico.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public MedicoRepository<Medico> Medicos { get; }
        public CitaRepository<Cita> Citas { get; }
        public GenericRepository<Diagnostico> Diagnosticos { get; }
        public PacienteRepository<Paciente> Pacientes{ get; }

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Citas = new CitaRepository<Cita>(_context);
            Medicos = new MedicoRepository<Medico>(_context);
            Diagnosticos = new GenericRepository<Diagnostico>(_context);
            Pacientes = new PacienteRepository<Paciente>(_context);
        }


        public int SaveChanges() => _context.SaveChanges();
    }
}
