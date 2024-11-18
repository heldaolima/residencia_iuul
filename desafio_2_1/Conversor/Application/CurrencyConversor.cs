namespace Conversor.Application;

using Conversor.Domain.Entities;
using Conversor.Infra.Request;

public class CurrencyConversor
{
    private RequestHandler handler = new RequestHandler();

    public async Task<(ConvertedPair?, String?)> Convert(ConversionPair pair)
    {
        var (conversionRate, error) = await handler.GetConversionRate(pair.Origin, pair.Destiny);
        if (error is not null)
        {
            return (null, error);
        }

        return (new ConvertedPair(pair, conversionRate), null);
    }
}
