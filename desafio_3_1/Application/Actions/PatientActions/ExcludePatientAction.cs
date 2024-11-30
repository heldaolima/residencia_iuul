namespace DentalOffice.Application.Actions;

using Domain.Entities;
using Domain.Interfaces;
using Validation;
using Validation.InputParsers;
using Validation.Validators;

public class DeletePatientAction : Action
{
    private IPatientRepository patientRepository;
    private IConsultationRepository consultationRepository;

    public DeletePatientAction(IPatientRepository pRepo, IConsultationRepository cRepo)
    {
        patientRepository = pRepo;
        consultationRepository = cRepo;
    }

    public async Task<ActionOptions> Run()
    {
        String cpf = await UserInputHandler.Handle(
                    "CPF: ",
                    new StringParser(),
                    new IsPatientRegisteredValidator(patientRepository)
                    );

        var patient = await patientRepository.GetPatientByCpf(cpf);
        if (patient is null)
            return ActionOptions.ShowPatientsMenu;

        if (patient.HasFutureConsultation())
            Console.WriteLine("Erro: paciente está agendado.");
        else
        {
            await consultationRepository.RemovePatient(patient);
            await patientRepository.RemovePatient(patient);
            Console.WriteLine("Paciente excluído com sucesso!");
        }

        return ActionOptions.ShowPatientsMenu;
    }
}
