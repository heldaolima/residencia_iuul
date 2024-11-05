namespace DentalOffice.Presentation.ActionMenus;

public class ListConsultationsInsidePeriod : ActionMenu
{
    public static MenuOptions Display()
    {
        Console.WriteLine("list consultations inside period");
        return MenuOptions.DisplayConsultationMenu;
    }
}
