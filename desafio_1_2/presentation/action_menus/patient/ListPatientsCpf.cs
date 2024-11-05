namespace DentalOffice.Presentation.ActionMenus;

public class ListPatientsByCpfMenu : ActionMenu
{
    public static MenuOptions Display()
    {
        Console.WriteLine("list patents by cpf menu");
        return MenuOptions.DisplayPatientsMenu;
    }

}
