namespace DentalOffice.Application.Actions;

using DentalOffice.Domain.Entities;
using DentalOffice.Utils;

public class ListPatientsByCpfAction : Action
{
    public static async Task<ActionOptions> Run()
    {
        /*var patients = Registration.Get().GetOrderedByCpf();*/
        /*PatientsPrinter.Print(patients);*/

        return ActionOptions.ShowPatientsMenu;
    }
}
