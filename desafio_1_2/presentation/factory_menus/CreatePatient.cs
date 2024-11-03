namespace DentalOffice.Presentation.FactoryMenus;

using DentalOffice.Validators;
using DentalOffice.Presentation.StaticMenus;

public class CreatePatient
{
    public static Menu.MenuOptions Create()
    {
        String name = InputValidator.ValidateInput(
            "Insira o nome do paciente: ",
            "Erro: o nome deve ter no mínimo 5 letras.",
            new NameValidator()
          );

        String cpf = InputValidator.ValidateInput(
            "Insira o CPF do paciente (apenas números): ",
            "Erro: CPF inválido.",
            new CPFValidator()
          );

        DateTime birthDate = InputValidator.ValidateInput(
            "Insira a data de nascimento [DDMMAAAA] (é necessário ter no mínimo 13 anos): ",
            "Erro: data de nascimento inválida.",
            new BirthDateValidator()
          );

        var patient = new Patient(name, cpf, birthDate);
        Registration.GetRegistration().Add(patient);

        return Menu.MenuOptions.DisplayPatientsMenu;
    }
}
