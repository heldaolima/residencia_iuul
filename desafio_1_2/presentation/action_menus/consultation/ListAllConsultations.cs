namespace DentalOffice.Presentation.ActionMenus;

public class ListAllConsultations : ActionMenu
{
    public static MenuOptions Display()
    {
        Console.WriteLine("list all consultations ");
        return MenuOptions.DisplayConsultationMenu;
    }
}
