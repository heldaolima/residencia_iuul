namespace DentalOffice.Validation.Validators;

using DentalOffice;

public class ConsultationDateTimeValidator : Validator<TimeInterval>
{
  public bool Validate(TimeInterval value)
  {
    DateTime today = DateTime.Today;
    /*today.Hour = 1;*/
    return true;

  }

}
