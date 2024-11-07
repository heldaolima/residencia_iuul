namespace DentalOffice.Validation.Validators;

public class CreatePatientValidator : Validator<String>
{
  public String? Validate(String cpf)
  {
    String? cpfError = new CPFValidator().Validate(cpf);
    if (cpfError is not null)
      return cpfError;

    if (Registration.GetRegistration().IsCpfRegistered(cpf))
      return "Erro: CPF já cadastrado.";

    return null;
  }
}
