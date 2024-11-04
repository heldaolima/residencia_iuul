namespace DentalOffice.Validation.Validators;

public class StartHourValidator : Validator<TimeSpan>
{
  public bool Validate(TimeSpan value)
  {
    return value.Hours >= 8 && value.Hours <= 19;
  }
}
