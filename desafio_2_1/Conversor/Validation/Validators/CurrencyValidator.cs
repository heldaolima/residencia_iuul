namespace Conversor.Validation.Validators;

public class CurrencyValidator : Validator<String>
{
  public String? Validate(String value)
  {
    if (value.Any((v) => char.IsDigit(v)))
    {
      return "Erro: não pode haver dígitos no código da moeda.";
    }

    if (value.Length > 0 && value.Length != 3)
      return "Erro: a moeda deve ter exatamente três caracteres.";

    return null;
  }
}
