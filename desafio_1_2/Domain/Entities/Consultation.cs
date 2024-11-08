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

  public bool IsInOrBefore(DateTime date) =>
    this.TimeSchedule.Start.Date.CompareTo(date.Date) <= 0;

  public bool IsInOrAfter(DateTime date) =>
    this.TimeSchedule.Start.Date.CompareTo(date.Date) >= 0;

}
