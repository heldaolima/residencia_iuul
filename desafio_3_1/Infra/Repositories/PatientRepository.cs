namespace DentalOffice.Infra.Repositories;

using DentalOffice.Domain.Entities;
using DentalOffice.Domain.Interfaces;
using DB;

using Microsoft.EntityFrameworkCore;

public class PatientRepository : IPatientRepository
{
  private readonly DentalOfficeDbContext context;

  public PatientRepository(DentalOfficeDbContext context)
  {
    this.context = context;
  }

  public Task<Patient?> GetPatientByCpf(string cpf)
  {
    return context.Patients.FirstOrDefaultAsync(p => p.CPF == cpf);
  }

  public async Task<List<Patient>> GetOrderedByName() =>
    await context.Patients.OrderBy(p => p.Name).ToListAsync();

  public async Task<List<Patient>> GetOrderedByCpf() =>
    await context.Patients.OrderBy(p => p.CPF).ToListAsync();

  public async Task AddPatient(Patient p)
  {
    await context.Patients.AddAsync(p);
    await context.SaveChangesAsync();
  }

  public async Task RemovePatient(Patient p)
  {
    context.Patients.Remove(p);
    await context.SaveChangesAsync();
  }

  public async Task<bool> IsCpfRegistered(string cpf)
  {
    var patient = await context.Patients.FirstOrDefaultAsync(p => p.CPF == cpf);
    return patient is not null;
  }
}
