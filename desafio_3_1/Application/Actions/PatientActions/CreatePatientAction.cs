namespace DentalOffice.Application.Actions;

using DentalOffice.Domain.Entities;
using DentalOffice.Validation.Validators;
using DentalOffice.Validation.InputParsers;
using DentalOffice.Validation;

public class CreatePatientAction : Action
{
    public static async Task<ActionOptions> Run()
    {
        String cpf = UserInputHandler.Handle(
                    "CPF: ",
                    new StringParser(),
                    new DoubleCpfValidator()
                    );

        String name = UserInputHandler.Handle(
            "Nome: ",
            new StringParser(),
            new NameValidator()
          );

        DateTime birthDate = UserInputHandler.Handle(
            "Data de nascimento [DDMMAAAA]: ",
            new DateTimeParser(),
            new BirthDateValidator()
          );

        /*Registration.Get().AddPatient(new Patient(name, cpf, birthDate));*/

        Console.WriteLine("Paciente cadastrado com sucesso!");

        return ActionOptions.ShowPatientsMenu;
    }
}
