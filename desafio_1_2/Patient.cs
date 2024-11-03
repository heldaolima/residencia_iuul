namespace DentalOffice;

public class Patient
{
  public String Name { get; private set; }
  public String CPF { get; private set; }
  public DateTime BirthDate { get; private set; }
  private List<Consultation> consultations;

  public Patient(String name, String cpf, DateTime birthDate)
  {
    Name = name;
    CPF = cpf;
    BirthDate = birthDate;
    consultations = new List<Consultation>();
  }
}
