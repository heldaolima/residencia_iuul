namespace DentalOffice;

class Registration
{
  private List<Patient> patients = new List<Patient>();
  private static Registration? registration = null;

  private Registration() { }

  public static Registration GetRegistration()
  {
    if (registration is null)
    {
      registration = new Registration();
    }
    return registration;
  }

  public void Add(Patient p)
  {
    patients.Add(p);
  }

  public bool Remove(Patient p)
  {
    return patients.Remove(p);
  }


  public Patient? GetPatientByCpf(String cpf)
  {
    return patients.Find((p) => p.CPF == cpf);
  }

  public bool IsCpfRegistered(String cpf)
  {
    return patients.Exists((p) => p.CPF == cpf);
  }
}
