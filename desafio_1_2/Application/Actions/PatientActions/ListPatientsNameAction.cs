namespace DentalOffice.Application.Actions;

using DentalOffice.Domain;
using DentalOffice.Utils;

public class ListPatientsByNameAction : Action
{
    public static ActionOptions Run()
    {
        var patients = Registration.Get().GetOrderedByName();

        PatientsPrinter.Print(patients);
        return ActionOptions.ShowPatientsMenu;
    }
}
