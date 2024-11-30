namespace DentalOffice.Validation.Validators;


public class ConsultationDateTimeValidator : Validator<DateTime>
{
  public Task<String?> Validate(DateTime value)
  {
    if (value < DateTime.Today)
      return Task.FromResult<string?>("Erro: a data não pode ser no passado.");
    return Task.FromResult<string?>(null);
  }
}
