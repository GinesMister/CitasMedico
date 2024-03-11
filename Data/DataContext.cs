using CitasMedico.Models;
using Microsoft.EntityFrameworkCore;

namespace CitasMedico.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Cita> Cita { get; set; }
        public DbSet<Diagnostico> Diagnostico { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<MedicoPaciente> MedicoPaciente { get; set; }
        public DbSet<Usuario> Usuario{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicoPaciente>()
                .HasKey(mp => new { mp.IdMedico, mp.IdPaciente });

            modelBuilder.Entity<MedicoPaciente>()
                .HasOne(mp => mp.Medico)
                .WithMany(m => m.pacientes)
                .HasForeignKey(mp => mp.IdMedico);

            modelBuilder.Entity<MedicoPaciente>()
                .HasOne(mp => mp.Paciente)
                .WithMany(p => p.Medicos)
                .HasForeignKey(mp => mp.IdPaciente);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Medico)
                .WithMany(m => m.Citas)
                .HasForeignKey(c => c.IdMedico);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Paciente)
                .WithMany(m => m.Citas)
                .HasForeignKey(c => c.IdPaciente);

            modelBuilder.Entity<Cita>()
                .HasOne(mp => mp.Diagnostico)
                .WithOne(dp => dp.Cita)
                .HasForeignKey<Diagnostico>(dp => dp.Id);

        }
    }
}
