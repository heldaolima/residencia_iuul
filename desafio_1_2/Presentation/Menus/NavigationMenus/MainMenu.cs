namespace DentalOffice.Presentation.Menus;

using DentalOffice.Application.Actions;

class MainMenu : NavigationMenu
{
  public MainMenu()
  {
    options.Add("Cadastro de paciente");
    options.Add("Agenda");
    options.Add("Fim");
  }

  public override ActionOptions ParseInput(int option)
  {
    return (option) switch
    {
      1 => ActionOptions.ShowPatientsMenu,
      2 => ActionOptions.ShowConsultationMenu,
      3 => ActionOptions.Terminate,
      _ => ActionOptions.ShowMenuAgain
    };
  }
}
