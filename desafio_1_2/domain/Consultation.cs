namespace DentalOffice.Domain;

using DentalOffice.Utils;

public class Consultation
{
  public Patient Patient { get; private set; }
  public TimeInterval TimeSchedule { get; private set; }

  public Consultation(Patient patient, TimeInterval timeSchedule)
  {
    Patient = patient;
    Patient.SetConsultation(this);

    TimeSchedule = timeSchedule;
  }
}
