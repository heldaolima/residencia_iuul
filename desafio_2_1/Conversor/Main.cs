namespace Conversor;

using Conversor.Validation;
using Conversor.Validation.InputParsers;
using Conversor.Validation.Validators;
using Conversor.Application;
using Conversor.Domain.Entities;

public class Program
{
    public async static Task<int> Main()
    {

        CurrencyConversor conversor;
        try
        {
            conversor = new CurrencyConversor();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return 1;
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

            var pair = new ConversionPair(originCurrency, destinyCurrency, value);

            Console.WriteLine();
            Console.WriteLine("Convertendo...");
            var (result, error) = await conversor.Convert(pair);
            Console.WriteLine();
            if (error is not null)
            {
                Console.WriteLine(error);
            }
            else if (result is not null)
            {
                result.PrintConversion();
            }
            Console.WriteLine();
        }
        return 0;
    }
}

