namespace DentalOffice.Validation.Validators;


public class ConsultationDateTimeValidator : Validator<DateTime>
{
  public String? Validate(DateTime value)
  {
    if (value < DateTime.Today)
      return "Erro: a data não pode ser no passado.";
    return null;
  }
}
