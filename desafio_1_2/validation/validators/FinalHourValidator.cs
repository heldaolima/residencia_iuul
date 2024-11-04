namespace DentalOffice.Validation.Validators;

public class FinalHourValidator : Validator<TimeSpan>
{
  private TimeSpan start;
  private TimeSpan limit = new TimeSpan(19, 0, 0);

  public FinalHourValidator(TimeSpan start)
  {
    this.start = start;
  }

  public bool Validate(TimeSpan value)
  {
    if (value >= start)
      return false;

    if (start.Add(value) > limit)
      return false;

    if (value.Minutes % 15 != 0)
      return false;

    return true;
  }
}
