namespace DentalOffice.Validation.Validators;

public class FinalHourValidator : Validator<TimeSpan>
{
  private TimeSpan start;
  private TimeSpan limit = new TimeSpan(19, 0, 0);

  public FinalHourValidator(TimeSpan start)
  {
    this.start = start;
  }

  public String? Validate(TimeSpan value)
  {
    if (value <= start)
      return "Erro: A hora final não pode ser antes da inicial.";

    if (value > limit)
      return "Erro: a consulta ultrapassa o horário de funcionamento do consultório (até às 19h00).";

    if (value.Minutes % 15 != 0)
      return "Erro: horários de consulta devem ser definidos de 15 em 15 minutos.";

    return null;
  }
}
