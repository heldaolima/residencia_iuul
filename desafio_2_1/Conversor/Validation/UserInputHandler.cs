namespace Conversor.Validation;

using Validation.InputParsers;
using Validation.Validators;

public class UserInputHandler
{
  public static T Handle<T>(String msg, InputParser<T> parser, Validator<T> validator)
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

      var validationError = validator.Validate(value);
      if (validationError is not null)
      {
        Console.WriteLine(validationError);
        continue;
      }

      return value;
    }
  }
}
