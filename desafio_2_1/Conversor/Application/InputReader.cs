namespace Conversor.Application;

using Conversor.Domain.Entities;
using Conversor.Validation;
using Conversor.Validation.InputParsers;
using Conversor.Validation.Validators;

public class InputReader
{
    public static ConversionPair? Run()
    {
        String originCurrency = UserInputHandler.Handle(
                "Moeda origem: ",
                new StringParser(),
                new CurrencyValidator()
                );

        if (originCurrency == "")
            return null;

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

        return new ConversionPair(originCurrency, destinyCurrency, value);
    }
}
