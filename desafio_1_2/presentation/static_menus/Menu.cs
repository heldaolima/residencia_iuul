namespace DentalOffice.Presentation.StaticMenus;

public abstract class Menu
{
  public enum MenuOptions
  {
    ShowAgain,
    Terminate,
    GoBackToMainMenu,

    DisplayPatientsMenu,
    DisplayAgendaMenu,

    DisplayRegisterPatientMenu,
    DisplayExcludePatientMenu,
    ListPatientsByCpf,
    ListPatientsByName,

    DisplayScheduleAppointmentMenu,
    DisplayCancelAppointmentMenu,
    DisplayListAppointmentsMenu,
  }

  protected List<String> options = new List<String>();

  private bool IsInsideBounds(int option) =>
    option > 0 && option <= options.Count();

  public MenuOptions Display()
  {
    Console.WriteLine();
    for (int i = 0; i < options.Count(); i++)
    {
      Console.WriteLine($"{i + 1}-{options[i]}");
    }

    Console.Write("Escolha: ");
    String? input = Console.ReadLine();

    if (input is null)
      return MenuOptions.ShowAgain;

    int option = 0;
    bool parsed = int.TryParse(input.Trim(), out option);

    if (parsed && IsInsideBounds(option))
    {
      return ParseInput(option);
    }

    return MenuOptions.ShowAgain;
  }

  public abstract MenuOptions ParseInput(int option);
}
