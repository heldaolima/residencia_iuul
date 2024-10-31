namespace DentalOffice.Presentation;

abstract class Menu
{
  protected List<String> options = new List<String>();

  private bool CheckBounds(int option)
  {
    return option - 1 <= 0 || option > options.Count();
  }

  public int Display()
  {
    for (int i = 0; i < options.Count(); i++)
    {
      Console.WriteLine($"{i + 1}-{options[i]}");
    }

    Console.Write("Sua escolha: ");
    String? input = Console.ReadLine();

    if (input is null)
      return -1;

    int option = 0;
    bool parsed = int.TryParse(input.Trim(), out option);

    if (parsed && CheckBounds(option))
      return ParseInput(option);
    return -1;
  }

  public abstract int ParseInput(int option);
}
