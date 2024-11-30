namespace DentalOffice.Infra.DB;

using DentalOffice.Domain.Entities;
using Env;
using Microsoft.EntityFrameworkCore;

public class DentalOfficeDbContext : DbContext
{
  public DbSet<Patient> Patients { get; set; }
  public DbSet<Consultation> Consultations { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    base.OnConfiguring(optionsBuilder);

    var env = new EnvHandler();

    string host = env.GetVar("DB_HOST");
    string port = env.GetVar("DB_PORT");
    string username = env.GetVar("DB_USER");
    string password = env.GetVar("DB_PASSWORD");
    string database = env.GetVar("DB_NAME");

    string connectionString = $"Host={host};Port={port};Username={username};Password={password};Database={database}";

    optionsBuilder.UseNpgsql(connectionString);
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Consultation>(entity =>
    {
      entity.HasOne(c => c.Patient)
        .WithMany(p => p.consultations)
        .HasForeignKey(c => c.PatientId);

      entity.OwnsOne(c => c.TimeSchedule, ts =>
      {
        ts.Property(t => t.Start).HasColumnName("Start").IsRequired();
        ts.Property(t => t.End).HasColumnName("End").IsRequired();
      });
    });
  }
}


