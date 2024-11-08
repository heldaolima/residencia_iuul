namespace DentalOffice;

class Registration
{
  private Dictionary<String, Patient> patients = new Dictionary<String, Patient>();
  private List<Consultation> consultations = new List<Consultation>();

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

  public void AddPatient(Patient p) => patients[p.CPF] = p;

  public void RemovePatient(Patient p)
  {
    consultations.RemoveAll((c) => c.Patient == p);
    patients.Remove(p.CPF);
  }

  public Patient? GetPatientByCpf(String cpf)
  {
    if (patients.ContainsKey(cpf))
      return patients[cpf];
    return null;
  }

  public bool IsCpfRegistered(String cpf) =>
    patients.ContainsKey(cpf);

  public bool RemovePatientByCpf(String cpf) => patients.Remove(cpf);

  public void AddConsultation(Consultation c) => consultations.Add(c);

  public bool RemoveConsultation(Consultation c) => consultations.Remove(c);

  public bool DoesConsultationTimeOverlaps(TimeInterval newInterval)
  {
    foreach (var consultation in consultations)
    {
      if (consultation.TimeSchedule.Overlaps(newInterval))
        return true;
    }
    return false;
  }
}
