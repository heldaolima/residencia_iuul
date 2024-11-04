namespace DentalOffice.Validation.Validators;

public class BirthDateValidator : Validator<DateTime>
{
  private int MinAge = 13;

  public bool Validate(DateTime value)
  {
    var yearsAgo = DateTime.Today.AddYears(-MinAge);
    return value <= yearsAgo;
  }
}
