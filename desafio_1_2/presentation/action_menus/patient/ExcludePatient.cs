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
                    new CPFValidator()
                    );

        if (Registration.GetRegistration().IsCpfRegistered(cpf))
        {
            bool removed = Registration.GetRegistration().RemoveByCpf(cpf);
            if (removed)
                Console.WriteLine("Paciente excluído com sucesso!");
            else
                Console.WriteLine("Erro ao excluir paciente. Tente novamente.");
        }
        else
            Console.WriteLine("Erro: paciente não registrado.");

        return MenuOptions.DisplayPatientsMenu;
    }
}
