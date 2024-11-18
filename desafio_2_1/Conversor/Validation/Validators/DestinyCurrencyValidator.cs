namespace Conversor.Validation.Validators;

public class DestinyCurrencyValidator : Validator<String>
{
  private String originCurrency;
  public DestinyCurrencyValidator(String originCurrency)
  {
    this.originCurrency = originCurrency;
  }

  public String? Validate(String value)
  {
    var currencyError = new CurrencyValidator().Validate(value);
    if (currencyError is not null)
      return currencyError;

    if (value == originCurrency)
      return "Erro: a moeda de destino não pode ser igual à moeda de origem.";

    return null;
  }
}
