namespace DentalOffice.Presentation.ActionMenus;

public class CancelConsultationMenu : ActionMenu
{
    public static MenuOptions Display()
    {
        Console.WriteLine("Cancel consultation menu");
        return MenuOptions.DisplayConsultationMenu;
    }
}
