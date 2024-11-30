namespace DentalOffice.Application.Actions;

using DentalOffice.Domain.Entities;
using DentalOffice.Utils;

public class ListPatientsByNameAction : Action
{
    public static async Task<ActionOptions> Run()
    {
        /*var patients = Registration.Get().GetOrderedByName();*/
        /**/
        /*PatientsPrinter.Print(patients);*/
        return ActionOptions.ShowPatientsMenu;
    }
}
