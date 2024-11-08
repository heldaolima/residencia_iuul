namespace DentalOffice.Validation.Validators;

public class GetPatientValidator : Validator<String>
{
  public String? Validate(String cpf)
  {
    String? cpfError = new CPFValidator().Validate(cpf);
    if (cpfError is not null)
      return cpfError;

    var patient = Registration.GetRegistration().GetPatientByCpf(cpf);
    if (patient is null)
      return "Erro: paciente não cadastrado.";

    return null;
  }
}
