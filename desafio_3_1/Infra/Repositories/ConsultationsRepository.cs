namespace DentalOffice.Infra.Repositories;

using Domain.Entities;
using Domain.Interfaces;
using DB;

using Microsoft.EntityFrameworkCore;

public class ConsultationRepository : IConsultationRepository
{
  private readonly DentalOfficeDbContext context;

  public ConsultationRepository(DentalOfficeDbContext context)
  {
    this.context = context;
  }

  public async Task<List<Consultation>> GetAll() =>
    await context.Consultations.Include(c => c.Patient).ToListAsync();

  public async Task AddConsultation(Consultation c)
  {
    await context.Consultations.AddAsync(c);
    await context.SaveChangesAsync();
  }

  public async Task RemoveConsultation(Consultation c)
  {
    context.Consultations.Remove(c);
    await context.SaveChangesAsync();
  }

  public async Task<bool> DoesConsultationTimeOverlaps(TimeInterval newInterval) =>
      await context.Consultations.AnyAsync(c => c.TimeSchedule.Overlaps(newInterval));

  public async Task RemovePatient(Patient p)
  {
    var consultations = await context.Consultations
      .Where(c => c.Patient.Id == p.Id)
      .ToListAsync();

    context.Consultations.RemoveRange(consultations);
    await context.SaveChangesAsync();
  }
}


