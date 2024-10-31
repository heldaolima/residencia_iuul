namespace DentalOffice;

class Registration
{
  private List<Patient> patients = new List<Patient>();

  public void Add(Patient p)
  {
    patients.Add(p);
  }

  public bool Remove(Patient p)
  {
    return patients.Remove(p);
  }
}
