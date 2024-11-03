namespace DentalOffice.Validators;

public class BirthDateValidator : Validator<DateTime>
{
  public (DateTime, bool) Validate(String value)
  {
    try
    {
      var (dataNascimento, valid) = new DateTimeValidator().Validate(value);
      if (!valid)
        return (dataNascimento, false);

      DateTime yearsAgo = DateTime.Today.AddYears(-13);
      return (dataNascimento, dataNascimento <= yearsAgo);
    }
    catch (FormatException)
    {
      return (new DateTime(), false);
    }
  }
}
