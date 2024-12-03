namespace DentalOffice.Application;

using Application.Actions;
using Presentation.Menus;
using Utils;

public class RequestsHandler
{
  public AppSession Session { get; private set; }

  public NavigationMenu? CurrentMenu { get; private set; }
  public RequestsHandler(AppSession session)
  {
    Session = session;
    CurrentMenu = new MainMenu();
  }

  public void SwitchMenu(ActionOptions action)
  {
    CurrentMenu = action switch
    {
      ActionOptions.ShowMainMenu => new MainMenu(),
      ActionOptions.ShowPatientsMenu => new PatientRegistrationMenu(),
      ActionOptions.ShowConsultationMenu => new ConsultationsMenu(),
      ActionOptions.ShowMenuAgain => CurrentMenu,
      ActionOptions.Terminate => null,

      _ => CurrentMenu
    };
  }

  public ActionOptions DisplayCurrentMenu()
  {
    if (CurrentMenu is not null)
      return CurrentMenu.Display();

    return ActionOptions.Terminate;
  }

  public async Task<ActionOptions> ExecuteRequest(ActionOptions request)
  {
    var action = ActionSwitcher.GetAction(request, Session);
    if (action is not null)
    {
      try
      {
        var response = await action.Run();
        return response;
      }
      catch (Exception)
      {
        Console.WriteLine("Erro interno no servidor. Tente novamente.");
      }
    }
    return request;
  }
}
