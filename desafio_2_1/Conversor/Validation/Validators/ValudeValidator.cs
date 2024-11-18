namespace Conversor.Validation.Validators;

public class ValueValidator : Validator<double>
{
  public String? Validate(double value)
  {
    if (value <= 0)
      return "Erro: o valor deve ser maior que zero.";

    return null;
  }
}
