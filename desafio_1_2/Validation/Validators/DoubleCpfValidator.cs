namespace DentalOffice.Validation.Validators;

using DentalOffice.Domain;

public class DoubleCpfValidator : Validator<String>
{
  public String? Validate(String cpf)
  {
    String? cpfError = new CPFValidator().Validate(cpf);
    if (cpfError is not null)
      return cpfError;

    if (Registration.Get().IsCpfRegistered(cpf))
      return "Erro: CPF já cadastrado.";

    return null;
  }
}
