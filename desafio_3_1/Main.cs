namespace DentalOffice;

using DentalOffice.Presentation.Menus;
using DentalOffice.Application.Actions;

class App
{
  public static async Task Main()
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
        ActionOptions.GoToRegisterPatientAction => await CreatePatientAction.Run(),
        ActionOptions.GoToExcludePatientAction => await DeletePatientAction.Run(),
        ActionOptions.GoToListPatientsByCpfAction => await ListPatientsByCpfAction.Run(),
        ActionOptions.GoToListPatientsByNameAction => await ListPatientsByNameAction.Run(),
        ActionOptions.GoToCreateConsultationAction => await CreateConsultationAction.Run(),
        ActionOptions.GoToCancelConsultationAction => await CancelConsultationAction.Run(),
        ActionOptions.GoToListConsultationsAction => await ListConsultationsAction.Run(),

        _ => action
      };
    }
  }
}
