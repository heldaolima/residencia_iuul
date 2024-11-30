namespace DentalOffice.Domain.Interfaces;

using DentalOffice.Domain.Entities;

public interface IPatientRepository
{
  Task<Patient?> GetPatientByCpf(string cpf);
  Task<List<Patient>> GetOrderedByName();
  Task<List<Patient>> GetOrderedByCpf();
  Task AddPatient(Patient p);
  Task RemovePatient(Patient p);
  Task<bool> IsCpfRegistered(string cpf);
}

