namespace DentalOffice.Validation.Validators;

using Domain.Entities;
using Domain.Interfaces;

public class DoubleCpfValidator : Validator<String>
{
  private readonly IPatientRepository repository;

  public DoubleCpfValidator(IPatientRepository repo)
  {
    repository = repo;
  }

  public async Task<String?> Validate(String cpf)
  {
    String? cpfError = await new CPFValidator().Validate(cpf);
    if (cpfError is not null)
      return cpfError;

    if (await repository.IsCpfRegistered(cpf))
      return "Erro: CPF já cadastrado.";

    return null;
  }
}
