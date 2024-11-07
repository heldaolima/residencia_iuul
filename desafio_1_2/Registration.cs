namespace DentalOffice;

class Registration
{
  // trocar por um hash[cpf] => patient
  // extract to patientsList
  private List<Patient> patients = new List<Patient>();
  // extract to Agenda
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

  public void AddPatient(Patient p) => patients.Add(p);

  public void RemovePatient(Patient p)
  {
    consultations.RemoveAll((c) => c.Patient == p);
    patients.Remove(p);
  }

  public Patient? GetPatientByCpf(String cpf) =>
    patients.Find((p) => p.CPF == cpf);

  public bool IsCpfRegistered(String cpf) =>
    patients.Exists((p) => p.CPF == cpf);

  public bool RemovePatientByCpf(String cpf)
  {
    int num = patients.RemoveAll((p) => p.CPF == cpf);
    return num > 0;
  }

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
