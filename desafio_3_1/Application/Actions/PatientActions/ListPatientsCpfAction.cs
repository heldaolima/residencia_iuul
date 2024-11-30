namespace DentalOffice.Application.Actions;

using Domain.Interfaces;
using Utils;

public class ListPatientsByCpfAction : Action
{
    private IPatientRepository patientRepository;

    public ListPatientsByCpfAction(IPatientRepository pRepo)
    {
        patientRepository = pRepo;
    }

    public async Task<ActionOptions> Run()
    {
        var patients = await patientRepository.GetOrderedByCpf();
        PatientsPrinter.Print(patients);

        return ActionOptions.ShowPatientsMenu;
    }
}
