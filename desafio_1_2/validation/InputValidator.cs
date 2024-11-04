namespace DentalOffice.Validation;

using DentalOffice.Validation.Parsers;
using DentalOffice.Validation.Validators;

public class InputValidator
{
  public static T ValidateInput<T>(String msg, String errorMsg, Parser<T> parser, Validator<T> validator)
  {
    while (true)
    {
      Console.Write(msg);
      String? fromUser = Console.ReadLine();
      if (fromUser is null)
        continue;

      var (value, isValid) = parser.Parse(fromUser.Trim());
      if (isValid && validator.Validate(value))
        return value;
      else
        Console.WriteLine(errorMsg);
    }
  }
}
