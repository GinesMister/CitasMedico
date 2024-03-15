using CitasMedico.Models;
using CitasMedico.Repository;

namespace CitasMedico.Interfaces
{
    public interface IUnitOfWork
    {
        GenericRepository<Cita> Citas { get; }
        GenericRepository<Diagnostico> Diagnosticos { get; }
        MedicoRepository<Medico> Medicos { get; }
        GenericRepository<Paciente> Pacientes { get; }
        GenericRepository<Usuario> Usuarios { get; }

        int SaveChanges();
    }
}