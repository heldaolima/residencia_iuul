namespace DentalOffice.Domain;

using DentalOffice.Utils;

public class Consultation
{
  public int Id { get; set; }
  public int PatientId { get; private set; }
  public Patient Patient { get; private set; }
  public TimeInterval TimeSchedule { get; private set; }

  protected Consultation() { }

  public Consultation(Patient patient, TimeInterval timeSchedule)
  {
    Patient = patient;
    TimeSchedule = timeSchedule;
  }

  public bool IsInOrBefore(DateTime date) =>
    this.TimeSchedule.Start.Date.CompareTo(date.Date) <= 0;

  public bool IsInOrAfter(DateTime date) =>
    this.TimeSchedule.Start.Date.CompareTo(date.Date) >= 0;

}
