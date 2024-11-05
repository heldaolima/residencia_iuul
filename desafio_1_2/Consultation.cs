namespace DentalOffice;

public class Consultation
{
  private Patient patient;
  private TimeInterval timeSchedule;

  public Consultation(Patient patient, TimeInterval timeSchedule)
  {
    this.patient = patient;
    this.timeSchedule = timeSchedule;
  }
}
