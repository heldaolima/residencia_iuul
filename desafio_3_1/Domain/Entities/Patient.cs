namespace DentalOffice.Domain.Entities;

public class Patient
{
  public int Id { get; set; }
  public string Name { get; private set; }
  public string CPF { get; private set; }
  public DateTime BirthDate { get; private set; }
  public int Age { get; private set; }

  public ICollection<Consultation> consultations { get; private set; } = new List<Consultation>();

  protected Patient() { }
  public Patient(String name, String cpf, DateTime birthDate)
  {
    Name = name;
    CPF = cpf;
    BirthDate = birthDate;
    Age = CalculateAge();
  }

  private int CalculateAge()
  {
    var today = DateTime.Today;
    int age = today.Year - BirthDate.Year;

    if (BirthDate.Date > today.AddYears(-age))
      age--;

    return age;
  }

  public bool HasFutureConsultation() => true;

  public void AddConsultation(Consultation c) => consultations.Add(c);

  public Consultation? GetFutureConsultationIfItStartsOnDate(DateTime startDate) => null;

  public void RemoveConsultation(Consultation c) => consultations.Remove(c);

  public override String ToString() =>
    $"{Name} | {CPF} | {BirthDate}";

}
