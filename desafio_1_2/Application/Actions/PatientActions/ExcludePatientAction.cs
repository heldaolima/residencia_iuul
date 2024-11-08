namespace DentalOffice.Application.Actions;

using DentalOffice.Domain;
using DentalOffice.Validation;
using DentalOffice.Validation.InputParsers;
using DentalOffice.Validation.Validators;

public class DeletePatientAction : Action
{
    public static ActionOptions Run()
    {
        String cpf = UserInputHandler.Handle(
                    "CPF: ",
                    new StringParser(),
                    new IsPatientRegisteredValidator()
                    );

        var registration = Registration.Get();
        var patient = registration.GetPatientByCpf(cpf);
        if (patient is null)
            return ActionOptions.ShowPatientsMenu;

        if (patient.HasFutureConsultation())
            Console.WriteLine("Erro: paciente está agendado.");
        else
        {
            registration.RemovePatient(patient);
            Agenda.Get().RemovePatient(patient);
            Console.WriteLine("Paciente excluído com sucesso!");
        }

        return ActionOptions.ShowPatientsMenu;
    }
}
