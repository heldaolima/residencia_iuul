namespace DentalOffice.Validators;

using DentalOffice;

public class ConsultationDateTimeValidator : Validator<TimeInterval>
{
  public (TimeInterval, bool) Validate(String value)
  {
    DateTime today = DateTime.Today;
    today.Hour = 1;

  }

}
