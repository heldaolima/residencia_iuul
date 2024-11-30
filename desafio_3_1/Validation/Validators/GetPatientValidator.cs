namespace DentalOffice.Validation.Validators;

using DentalOffice.Domain;

public class GetPatientValidator : Validator<String>
{
  public String? Validate(String cpf)
  {
    String? cpfError = new CPFValidator().Validate(cpf);
    if (cpfError is not null)
      return cpfError;

    /*var patient = Registration.Get().GetPatientByCpf(cpf);*/
    /*if (patient is null)*/
    /*  return "Erro: paciente não cadastrado.";*/

    return null;
  }
}
