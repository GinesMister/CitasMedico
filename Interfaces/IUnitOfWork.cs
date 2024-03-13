using CitasMedico.Models;
using CitasMedico.Repository;

namespace CitasMedico.Interfaces
{
    public interface IUnitOfWork
    {
        CitasMedicoRepository<Cita> Citas { get; }
        CitasMedicoRepository<Diagnostico> Diagnosticos { get; }
        CitasMedicoRepository<Medico> Medicos { get; }
        CitasMedicoRepository<Paciente> Pacientes { get; }
        CitasMedicoRepository<Usuario> Usuarios { get; }

        int SaveChanges();
    }
}