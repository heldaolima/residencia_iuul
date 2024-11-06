namespace DentalOffice.Presentation.StaticMenus;

class ConsultationsMenu : StaticMenu
{
  public ConsultationsMenu()
  {
    options.Add("Agendar consulta");
    options.Add("Cancelar agendamento");
    options.Add("Listar agenda");
    options.Add("Voltar p/ menu principal");
  }

  public override MenuOptions ParseInput(int option)
  {
    return (option) switch
    {
      1 => MenuOptions.DisplayCreateConsultationMenu,
      2 => MenuOptions.DisplayCancelConsultationMenu,
      3 => MenuOptions.DisplayChooseListConsultationsMenu,
      4 => MenuOptions.GoBackToMainMenu,
      _ => MenuOptions.ShowAgain,
    };
  }
}
