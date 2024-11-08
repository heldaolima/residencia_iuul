namespace DentalOffice.Presentation.Menus;

using DentalOffice.Application.Actions;

public abstract class NavigationMenu
{
  protected List<String> options = new List<String>();

  private bool IsInsideBounds(int option) =>
    option > 0 && option <= options.Count();

  public ActionOptions Display()
  {
    Console.WriteLine();
    for (int i = 0; i < options.Count(); i++)
    {
      Console.WriteLine($"{i + 1}-{options[i]}");
    }

    Console.Write("Escolha: ");
    String? input = Console.ReadLine();

    if (input is null)
      return ActionOptions.ShowMenuAgain;

    int option = 0;
    bool parsed = int.TryParse(input.Trim(), out option);

    if (parsed && IsInsideBounds(option))
    {
      return ParseInput(option);
    }

    return ActionOptions.ShowMenuAgain;
  }

  public abstract ActionOptions ParseInput(int option);
}
