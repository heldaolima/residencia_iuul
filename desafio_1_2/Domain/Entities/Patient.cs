namespace DentalOffice.Domain;

public class Patient
{
  public String Name { get; private set; }
  public String CPF { get; private set; }
  public DateTime BirthDate { get; private set; }
  public int Age { get; private set; }
  public Consultation? Consultation { get; private set; }

  private List<Consultation> consultations;

  public Patient(String name, String cpf, DateTime birthDate)
  {
    Name = name;
    CPF = cpf;
    BirthDate = birthDate;
    Age = CalculateAge();

    Consultation = null;
    consultations = new List<Consultation>();
  }

  private int CalculateAge()
  {
    var today = DateTime.Today;
    int age = today.Year - BirthDate.Year;

    if (BirthDate.Date > today.AddYears(-age))
      age--;

    return age;
  }

  public bool HasFutureConsultation() => Consultation is not null;

  public void SetConsultation(Consultation c) => Consultation = c;

  public bool IsTheSameConsultation(DateTime startDate) =>
    Consultation?.TimeSchedule.Start == startDate;

  public void RemoveConsultation() => Consultation = null;

  public override String ToString() =>
    $"{Name} | {CPF} | {BirthDate}";

}
