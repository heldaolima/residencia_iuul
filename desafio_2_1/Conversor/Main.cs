using Conversor.Validation;
using Conversor.Validation.InputParsers;
using Conversor.Validation.Validators;

while (true)
{
  String originCurrency = UserInputHandler.Handle(
      "Moeda origem: ",
      new StringParser(),
      new CurrencyValidator()
      );

  if (originCurrency == "")
    break;

  String destinyCurrency = UserInputHandler.Handle(
      "Moeda destino: ",
      new StringParser(),
      new DestinyCurrencyValidator(originCurrency)
      );

  double value = UserInputHandler.Handle(
      "Valor: ",
      new DoubleParser(),
      new ValueValidator()
      );

  Console.WriteLine(value);
}
