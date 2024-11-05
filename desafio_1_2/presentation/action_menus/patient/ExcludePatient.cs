namespace DentalOffice.Presentation.ActionMenus;

public class DeletePatientMenu : ActionMenu
{
    public static MenuOptions Display()
    {
        Console.WriteLine("Delete patients menu");
        return MenuOptions.DisplayPatientsMenu;
    }
}
