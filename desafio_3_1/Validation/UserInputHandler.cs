namespace DentalOffice.Validation;

using DentalOffice.Validation.InputParsers;
using DentalOffice.Validation.Validators;

public class UserInputHandler
{
  public static async Task<T> Handle<T>(String msg, InputParser<T> parser, Validator<T> validator)
  {
    while (true)
    {
      Console.Write(msg);
      String? fromUser = Console.ReadLine();
      if (fromUser is null)
        continue;

      var (value, isValid) = parser.Parse(fromUser.Trim());
      if (!isValid)
      {
        Console.WriteLine(parser.ParseError());
        continue;
      }

      var validationError = await validator.Validate(value);
      if (validationError is not null)
      {
        Console.WriteLine(validationError);
        continue;
      }

      return value;
    }
  }
}
