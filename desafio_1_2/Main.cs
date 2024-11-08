namespace DentalOffice;

using DentalOffice.Presentation.Menus;
using DentalOffice.Application.Actions;

class App
{
  public static void Main()
  {
    var mainMenu = new MainMenu();
    var patientRegistrationMenu = new PatientRegistrationMenu();
    var consultationsMenu = new ConsultationsMenu();

    NavigationMenu? currentMenu = mainMenu;
    var action = ActionOptions.ShowMainMenu;
    while (true)
    {
      currentMenu = action switch
      {
        ActionOptions.ShowMainMenu => mainMenu,
        ActionOptions.ShowPatientsMenu => patientRegistrationMenu,
        ActionOptions.ShowConsultationMenu => consultationsMenu,
        ActionOptions.ShowMenuAgain => currentMenu,
        ActionOptions.Terminate => null,

        _ => currentMenu
      };

      if (action == ActionOptions.Terminate || currentMenu is null)
        break;

      action = currentMenu.Display();

      action = action switch
      {
        ActionOptions.GoToRegisterPatientAction => CreatePatientAction.Run(),
        ActionOptions.GoToExcludePatientAction => DeletePatientAction.Run(),
        ActionOptions.GoToListPatientsByCpfAction => ListPatientsByCpfAction.Run(),
        ActionOptions.GoToListPatientsByNameAction => ListPatientsByNameAction.Run(),
        ActionOptions.GoToCreateConsultationAction => CreateConsultationAction.Run(),
        ActionOptions.GoToCancelConsultationAction => CancelConsultationAction.Run(),
        ActionOptions.GoToListConsultationsAction => ListConsultationsAction.Run(),

        _ => action
      };
    }
  }
}
