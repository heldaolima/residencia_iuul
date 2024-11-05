namespace DentalOffice.Presentation.StaticMenus;

public class ChooseListConsultationsMenu : Menu
{
  public ChooseListConsultationsMenu()
  {
    options.Add("Listar agenda completa");
    options.Add("Listar agenda de um período");
  }

  public override MenuOptions ParseInput(int option)
  {
    return (option) switch
    {
      1 => MenuOptions.DisplayListAllConsultations,
      2 => MenuOptions.DisplayListConsultationsInsidePeriod,
      _ => MenuOptions.ShowAgain,
    };
  }
}
