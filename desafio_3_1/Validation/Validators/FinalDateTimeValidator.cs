namespace DentalOffice.Validation.Validators;

public class FinalDateTimeValidator : Validator<DateTime>
{
  private DateTime initial;
  public FinalDateTimeValidator(DateTime initial)
  {
    this.initial = initial;
  }

  public String? Validate(DateTime value)
  {
    if (value < initial)
      return "Erro: a data final não pode ser anterior à inicial.";
    return null;
  }
}
