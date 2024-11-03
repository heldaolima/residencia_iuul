namespace DentalOffice.Presentation.StaticMenus;

class AgendaMenu : Menu
{
  public AgendaMenu()
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
      1 => MenuOptions.DisplayScheduleAppointmentMenu,
      2 => MenuOptions.DisplayCancelAppointmentMenu,
      3 => MenuOptions.DisplayListAppointmentsMenu,
      _ => MenuOptions.ShowAgain,
    };
  }
}
