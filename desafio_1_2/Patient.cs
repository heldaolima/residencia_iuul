namespace DentalOffice;

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

    Consultation = null;
    consultations = new List<Consultation>();
  }

  public bool HasFutureConsultation() => Consultation is not null;

  public void SetConsultation(Consultation c) => Consultation = c;

  public override String ToString() =>
    $"{Name} | {CPF} | {BirthDate}";
}
