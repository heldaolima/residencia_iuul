namespace DentalOffice.Validators;

class InputValidator
{
  public static T ValidateInput<T>(String msg, String errorMsg, Validator<T> validator)
  {
    while (true)
    {
      Console.Write(msg);
      String? fromUser = Console.ReadLine();
      if (fromUser is null)
        continue;

      fromUser = fromUser.Trim();

      var (value, isValid) = validator.Validate(fromUser);
      if (isValid)
        return value;
      else
        Console.WriteLine(errorMsg);
    }
  }
}
