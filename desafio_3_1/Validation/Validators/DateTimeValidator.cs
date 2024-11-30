namespace DentalOffice.Validation.Validators;

public class DateTimeValidator : Validator<DateTime>
{
  public Task<String?> Validate(DateTime value) => Task.FromResult<string?>(null);
}
