namespace DentalOffice.Presentation.ActionMenus;

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
                    new GetPatientValidator()
                    );

        var registration = Registration.GetRegistration();

        var patient = registration.GetPatientByCpf(cpf);
        if (patient is null)
            return MenuOptions.DisplayPatientsMenu;

        if (patient.HasFutureConsultation())
        {
            Console.WriteLine("Erro: paciente está agendado.");
        }
        else
        {
            Registration.GetRegistration().RemovePatient(patient);
            Console.WriteLine("Paciente excluído com sucesso!");
        }

        return MenuOptions.DisplayPatientsMenu;
    }
}
