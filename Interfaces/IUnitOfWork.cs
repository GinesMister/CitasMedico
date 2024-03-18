using CitasMedico.Models;
using CitasMedico.Repository;

namespace CitasMedico.Interfaces
{
    public interface IUnitOfWork
    {
        CitaRepository<Cita> Citas { get; }
        GenericRepository<Diagnostico> Diagnosticos { get; }
        MedicoRepository<Medico> Medicos { get; }
        PacienteRepository<Paciente> Pacientes { get; }

        int SaveChanges();
    }
}