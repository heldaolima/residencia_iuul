namespace DentalOffice.Application.Actions;

using Domain.Interfaces;
using Domain.Entities;
using Validation.Validators;
using Validation.InputParsers;
using Validation;

public class CreatePatientAction : Action
{
    private IPatientRepository patientRepository;

    public CreatePatientAction(IPatientRepository pRepo)
    {
        patientRepository = pRepo;
    }

    public async Task<ActionOptions> Run()
    {
        String cpf = await UserInputHandler.Handle(
                    "CPF: ",
                    new StringParser(),
                    new DoubleCpfValidator(patientRepository)
                    );

        String name = await UserInputHandler.Handle(
            "Nome: ",
            new StringParser(),
            new NameValidator()
          );

        DateTime birthDate = await UserInputHandler.Handle(
            "Data de nascimento [DDMMAAAA]: ",
            new DateTimeParser(),
            new BirthDateValidator()
          );

        await patientRepository.AddPatient(new Patient(name, cpf, birthDate));

        Console.WriteLine("Paciente cadastrado com sucesso!");

        return ActionOptions.ShowPatientsMenu;
    }
}
