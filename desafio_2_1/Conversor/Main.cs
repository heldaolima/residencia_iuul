namespace Conversor;

using Conversor.Application;

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
            var pair = InputReader.Run();
            if (pair is null)
                break;

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

        Console.WriteLine();
        Console.WriteLine("Encerrando...");
        return 0;
    }
}

