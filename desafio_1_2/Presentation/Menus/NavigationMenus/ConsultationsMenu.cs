namespace DentalOffice.Presentation.Menus;

using DentalOffice.Application.Actions;

class ConsultationsMenu : NavigationMenu
{
  public ConsultationsMenu()
  {
    options.Add("Agendar consulta");
    options.Add("Cancelar agendamento");
    options.Add("Listar agenda");
    options.Add("Voltar p/ menu principal");
  }

  public override ActionOptions ParseInput(int option)
  {
    return (option) switch
    {
      1 => ActionOptions.GoToCreateConsultationAction,
      2 => ActionOptions.GoToCancelConsultationAction,
      3 => ActionOptions.GoToListConsultationsAction,
      4 => ActionOptions.ShowMainMenu,
      _ => ActionOptions.ShowMenuAgain,
    };
  }
}
