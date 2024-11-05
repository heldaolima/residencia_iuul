namespace DentalOffice.Presentation.StaticMenus;

class MainMenu : Menu
{
  public MainMenu()
  {
    options.Add("Cadastro de paciente");
    options.Add("Agenda");
    options.Add("Fim");
  }

  public override MenuOptions ParseInput(int option)
  {
    return (option) switch
    {
      1 => MenuOptions.DisplayPatientsMenu,
      2 => MenuOptions.DisplayConsultationMenu,
      3 => MenuOptions.Terminate,
      _ => MenuOptions.ShowAgain
    };
  }
}
