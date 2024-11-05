namespace DentalOffice.Presentation.ActionMenus;

public class ListPatientsByNameMenu : ActionMenu
{
    public static MenuOptions Display()
    {
        Console.WriteLine("List patients by name menu.");
        return MenuOptions.DisplayPatientsMenu;
    }
}
