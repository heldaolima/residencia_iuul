namespace DentalOffice.Presentation;

class MainMenu : Menu
{
  public MainMenu()
  {
    options.Add("Cadastro de paciente");
    options.Add("Agenda");
    options.Add("Fim");
  }

  public override int ParseInput(int option)
  {
    return -1;
  }
}
