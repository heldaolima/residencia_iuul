namespace DentalOffice.Presentation;

class AgendaMenu : Menu
{
  public AgendaMenu()
  {
    options.Add("Agendar consulta");
    options.Add("Cancelar agendamento");
    options.Add("Listar agenda");
    options.Add("Voltar p/ menu principal");
  }

  public override int ParseInput(int option)
  {
    return -1;
  }
}
