namespace DentalOffice.Presentation.ActionMenus;

using DentalOffice.Domain;
using DentalOffice.Validation;
using DentalOffice.Validation.Parsers;
using DentalOffice.Validation.Validators;

public class DeletePatientMenu : ActionMenu
{
    public static MenuOptions Display()
    {
        String cpf = InputValidator.ValidateInput(
                    "CPF: ",
                    new StringParser(),
                    new IsPatientRegisteredValidator()
                    );

        var registration = Registration.Get();
        var patient = registration.GetPatientByCpf(cpf);
        if (patient is null)
            return MenuOptions.DisplayPatientsMenu;

        if (patient.HasFutureConsultation())
            Console.WriteLine("Erro: paciente está agendado.");
        else
        {
            registration.RemovePatient(patient);
            Agenda.Get().RemovePatient(patient);
            Console.WriteLine("Paciente excluído com sucesso!");
        }

        return MenuOptions.DisplayPatientsMenu;
    }
}
