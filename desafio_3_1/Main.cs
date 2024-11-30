namespace DentalOffice;

using Application;
using Application.Actions;

class App
{
  public static async Task Main()
  {
    var session = AppSession.InitSession();

    var handler = new RequestsHandler(session);
    var action = ActionOptions.ShowMainMenu;

    while (true)
    {
      handler.SwitchMenu(action);

      if (action == ActionOptions.Terminate)
        break;

      action = handler.DisplayCurrentMenu();

      action = await handler.ExecuteRequest(action);
    }
  }
}
