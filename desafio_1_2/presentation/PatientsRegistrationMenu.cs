namespace DentalOffice.Presentation;

class PatientRegistrationMenu : Menu
{
  public PatientRegistrationMenu()
  {
    options.Add("Cadastrar novo paciente");
    options.Add("Excluir paciente");
    options.Add("Listar pacientes (ordenado por CPF)");
    options.Add("Listar pacientes (ordenado por nome)");
    options.Add("Voltar p/ menu principal");
  }

  public override int ParseInput(int option)
  {
    return -1;
  }
}
