namespace DentalOffice.Presentation.FactoryMenus;

using DentalOffice.Validation.Validators;
using DentalOffice.Validation.Parsers;
using DentalOffice.Validation;
using DentalOffice.Presentation.StaticMenus;

public class CreatePatient
{
    public static Menu.MenuOptions Create()
    {
        String name = InputValidator.ValidateInput(
            "Insira o nome do paciente: ",
            "Erro: o nome deve ter no mínimo 5 letras.",
            new StringParser(),
            new NameValidator()
          );

        String cpf = InputValidator.ValidateInput(
            "Insira o CPF do paciente (apenas números): ",
            "Erro: CPF inválido.",
            new StringParser(),
            new CPFValidator()
          );

        DateTime birthDate = InputValidator.ValidateInput(
            "Insira a data de nascimento [DDMMAAAA] (é necessário ter no mínimo 13 anos): ",
            "Erro: data de nascimento inválida.",
            new DateTimeParser(),
            new BirthDateValidator()
          );

        var patient = new Patient(name, cpf, birthDate);
        Registration.GetRegistration().Add(patient);

        Console.WriteLine(patient);
        Console.WriteLine($"Paciente adicionado.");

        return Menu.MenuOptions.DisplayPatientsMenu;
    }
}
