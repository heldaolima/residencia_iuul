namespace DentalOffice.Validation.Validators;

public class FinalDateTimeValidator : Validator<DateTime>
{
  private DateTime initial;
  public FinalDateTimeValidator(DateTime initial)
  {
    this.initial = initial;
  }

  public Task<String?> Validate(DateTime value)
  {
    if (value < initial)
      return Task.FromResult<string?>("Erro: a data final não pode ser anterior à inicial.");
    return Task.FromResult<string?>(null);
  }
}
