namespace DentalOffice.Validation.Validators;

public class FinalHourValidator : Validator<TimeSpan>
{
  private TimeSpan start;
  private TimeSpan limit = new TimeSpan(19, 0, 0);

  public FinalHourValidator(TimeSpan start)
  {
    this.start = start;
  }

  public Task<String?> Validate(TimeSpan value)
  {
    if (value <= start)
      return Task.FromResult<string?>("Erro: A hora final não pode ser antes da inicial.");

    if (value > limit)
      return Task.FromResult<string?>("Erro: a consulta ultrapassa o horário de funcionamento do consultório (até às 19h00).");

    if (value.Minutes % 15 != 0)
      return Task.FromResult<string?>("Erro: horários de consulta devem ser definidos de 15 em 15 minutos.");

    return Task.FromResult<string?>(null);
  }
}
