namespace DentalOffice.Presentation.ActionMenus;

using DentalOffice.Validation.Validators;
using DentalOffice.Validation.Parsers;
using DentalOffice.Validation;

public class CreatePatientMenu : ActionMenu
{
    public static MenuOptions Display()
    {
        String cpf;
        while (true)
        {
            cpf = InputValidator.ValidateInput(
                    "CPF: ",
                    new StringParser(),
                    new CPFValidator()
                    );

            if (Registration.GetRegistration().IsCpfRegistered(cpf))
            {
                Console.WriteLine("Erro: CPF já cadastrado");
                continue;
            }
            break;
        }

        String name = InputValidator.ValidateInput(
            "Nome: ",
            new StringParser(),
            new NameValidator()
          );


        DateTime birthDate = InputValidator.ValidateInput(
            "Data de nascimento [DDMMAAAA]: ",
            new DateTimeParser(),
            new BirthDateValidator()
          );

        var patient = new Patient(name, cpf, birthDate);
        Registration.GetRegistration().Add(patient);

        Console.WriteLine("Paciente cadastrado com sucesso!");

        return MenuOptions.DisplayPatientsMenu;
    }
}
