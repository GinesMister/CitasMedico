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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medico>()
                .HasMany(m => m.Pacientes)
                .WithMany(p => p.Medicos)
                .UsingEntity(j => j.ToTable("MedicoPaciente"));

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Medico)
                .WithMany(m => m.Citas)
                .HasForeignKey(c => c.IdMedico);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Paciente)
                .WithMany(m => m.Citas)
                .HasForeignKey(c => c.IdPaciente);

            modelBuilder.Entity<Diagnostico>()
                .HasOne(mp => mp.Cita)
                .WithOne(dp => dp.Diagnostico)
                .HasForeignKey<Cita>(dp => dp.Id);
        }
    }
}