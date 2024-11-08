namespace DentalOffice.Domain;

using DentalOffice.Utils;
using System.Collections.ObjectModel;

public class Agenda
{
  private List<Consultation> consultations = new List<Consultation>();
  public ReadOnlyCollection<Consultation> Consultations => consultations.AsReadOnly();

  private static Agenda? agenda = null;
  private Agenda() { }

  public static Agenda Get()
  {
    if (agenda is null)
      agenda = new Agenda();
    return agenda;
  }

  public void AddConsultation(Consultation c) => consultations.Add(c);

  public void RemoveConsultation(Consultation c)
  {
    consultations.Remove(c);
    c.Patient.RemoveConsultation();
  }

  public bool DoesConsultationTimeOverlaps(TimeInterval newInterval)
  {
    foreach (var consultation in consultations)
    {
      if (consultation.TimeSchedule.Overlaps(newInterval))
        return true;
    }
    return false;
  }

  public void RemovePatient(Patient p) =>
    consultations.RemoveAll((c) => c.Patient == p);
}
