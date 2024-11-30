namespace DentalOffice.Domain;

using System.Collections.ObjectModel;

public class Registration
{
  private SortedDictionary<String, Patient> patients = new SortedDictionary<String, Patient>();

  private static Registration? registration = null;

  private Registration() { }

  public static Registration Get()
  {
    if (registration is null)
    {
      registration = new Registration();
    }
    return registration;
  }

  public ReadOnlyCollection<Patient> GetOrderedByCpf() => patients.Values.ToList().AsReadOnly();

  public ReadOnlyCollection<Patient> GetOrderedByName() =>
    patients.Values.OrderBy(patient => patient.Name).ToList().AsReadOnly();

  public void AddPatient(Patient p) => patients[p.CPF] = p;

  public void RemovePatient(Patient p) =>
    patients.Remove(p.CPF);

  public Patient? GetPatientByCpf(String cpf)
  {
    if (patients.ContainsKey(cpf))
      return patients[cpf];
    return null;
  }

  public bool IsCpfRegistered(String cpf) =>
    patients.ContainsKey(cpf);

  public bool RemovePatientByCpf(String cpf) => patients.Remove(cpf);
}
