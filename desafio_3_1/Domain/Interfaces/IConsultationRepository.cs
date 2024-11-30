namespace DentalOffice.Domain.Interfaces;

using Domain.Entities;

public interface IConsultationRepository
{
  Task<List<Consultation>> GetAll();
  Task AddConsultation(Consultation c);
  Task RemoveConsultation(Consultation c);
  Task<bool> DoesConsultationTimeOverlaps(TimeInterval newInterval);
  Task RemovePatient(Patient p);
}
