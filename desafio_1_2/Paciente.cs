namespace DentalOffice;

class Patient
{
  public String Name { get; private set; }
  public String CPF { get; private set; }
  public DateTime BirthDate { get; private set; }

  public Patient(String name, String cpf, DateTime birthDate)
  {
    Name = name;
    CPF = cpf;
    BirthDate = birthDate;
  }
}
