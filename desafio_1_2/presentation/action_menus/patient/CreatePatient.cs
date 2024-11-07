namespace DentalOffice.Presentation.ActionMenus;

using DentalOffice.Validation.Validators;
using DentalOffice.Validation.Parsers;
using DentalOffice.Validation;

public class CreatePatientMenu : ActionMenu
{
    public static MenuOptions Display()
    {
        String cpf = InputValidator.ValidateInput(
                    "CPF: ",
                    new StringParser(),
                    new CreatePatientValidator()
                    );

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
        Registration.GetRegistration().AddPatient(patient);

        Console.WriteLine("Paciente cadastrado com sucesso!");

        return MenuOptions.DisplayPatientsMenu;
    }
}
