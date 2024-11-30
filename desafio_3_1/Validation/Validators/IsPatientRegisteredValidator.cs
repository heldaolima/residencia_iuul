namespace DentalOffice.Validation.Validators;

using Domain.Interfaces;
using Domain.Entities;

public class IsPatientRegisteredValidator : Validator<String>
{
  private readonly IPatientRepository repository;

  public IsPatientRegisteredValidator(IPatientRepository repo)
  {
    repository = repo;
  }

  public async Task<String?> Validate(String cpf)
  {
    String? cpfError = await new CPFValidator().Validate(cpf);
    if (cpfError is not null)
      return cpfError;

    var patient = await repository.GetPatientByCpf(cpf);
    if (patient is null)
      return "Erro: paciente não cadastrado.";

    return null;
  }
}
