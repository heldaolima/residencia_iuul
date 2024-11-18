
using Conversor.Validation;
using Conversor.Infra.Request;
using Conversor.Validation.InputParsers;
using Conversor.Validation.Validators;

RequestHandler rh;
try
{
    rh = new RequestHandler();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    System.Environment.Exit(1);
}

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
