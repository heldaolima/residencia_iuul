namespace DentalOffice.Presentation.ActionMenus;

using DentalOffice.Validation.Validators;
using DentalOffice.Validation.Parsers;
using DentalOffice.Validation;

public class CreatePatientMenu : ActionMenu
{
    public static MenuOptions Display()
    {
        String name = InputValidator.ValidateInput(
            "Insira o nome do paciente: ",
            new StringParser(),
            new NameValidator()
          );

        String cpf;
        while (true)
        {
            cpf = InputValidator.ValidateInput(
                    "Insira o CPF do paciente (apenas números): ",
                    new StringParser(),
                    new CPFValidator()
                    );

            if (Registration.GetRegistration().IsCpfRegistered(cpf))
            {
                Console.WriteLine("Erro: O CPF inserido já foi registrado.");
                continue;
            }
            break;
        }

        DateTime birthDate = InputValidator.ValidateInput(
            "Insira a data de nascimento [DDMMAAAA] (é necessário ter no mínimo 13 anos): ",
            new DateTimeParser(),
            new BirthDateValidator()
          );

        var patient = new Patient(name, cpf, birthDate);
        Registration.GetRegistration().Add(patient);

        Console.WriteLine(patient);
        Console.WriteLine($"Paciente adicionado.");

        return MenuOptions.DisplayPatientsMenu;
    }
}
