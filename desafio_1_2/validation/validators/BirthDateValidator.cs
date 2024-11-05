namespace DentalOffice.Validation.Validators;

public class BirthDateValidator : Validator<DateTime>
{
  private int MinAge = 13;

  public String? Validate(DateTime value)
  {
    var yearsAgo = DateTime.Today.AddYears(-MinAge);
    if (value <= yearsAgo)
      return null;

    return $"Erro: Não são aceitas pessoas com menos de {MinAge} anos.";
  }
}
