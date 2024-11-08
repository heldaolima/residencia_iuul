namespace DentalOffice.Validation.Validators;

public class BirthDateValidator : Validator<DateTime>
{
  private const int MinAge = 13;

  public String? Validate(DateTime value)
  {
    var yearsAgo = DateTime.Today.AddYears(-MinAge);
    if (value <= yearsAgo)
      return null;

    return $"Erro: paciente deve ter pelo menos {MinAge} anos.";
  }
}
