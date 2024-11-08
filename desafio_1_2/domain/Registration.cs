namespace DentalOffice.Domain;

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

  public List<Patient> GetOrderedByCpf() => patients.Values.ToList();

  public List<Patient> GetOrderedByName() =>
    patients.Values.OrderBy(patient => patient.Name).ToList();

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
