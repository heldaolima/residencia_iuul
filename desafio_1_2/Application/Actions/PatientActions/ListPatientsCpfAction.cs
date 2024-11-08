namespace DentalOffice.Application.Actions;

using DentalOffice.Domain;
using DentalOffice.Utils;

public class ListPatientsByCpfAction : Action
{
    public static ActionOptions Run()
    {
        var patients = Registration.Get().GetOrderedByCpf();
        PatientsPrinter.Print(patients);

        return ActionOptions.ShowPatientsMenu;
    }
}
