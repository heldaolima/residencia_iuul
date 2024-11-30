namespace DentalOffice.Application.Actions;

using Domain.Interfaces;
using Utils;

public class ListPatientsByNameAction : Action
{
    private IPatientRepository patientRepository;

    public ListPatientsByNameAction(IPatientRepository pRepo)
    {
        patientRepository = pRepo;
    }

    public async Task<ActionOptions> Run()
    {
        var patients = await patientRepository.GetOrderedByName();

        PatientsPrinter.Print(patients);
        return ActionOptions.ShowPatientsMenu;
    }
}
