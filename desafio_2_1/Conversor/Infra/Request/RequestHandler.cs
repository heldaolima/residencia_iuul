namespace Conversor.Infra.Request;

using Infra.Env;
using Infra.Json;

public class RequestHandler
{

  private String ApiKey;
  private HttpClient client;

  public RequestHandler()
  {
    var key = new EnvHandler().GetApiKey();
    if (key is null)
    {
      throw new Exception("Erro: chave de API não encontrada.");
    }

    ApiKey = key;
    client = new()
    {
      BaseAddress = new Uri($"https://v6.exchangerate-api.com/v6/{ApiKey}/pair/"),
    };
  }

  public async Task<(double, String?)> GetConversionRate(string origin, string destiny)
  {
    try
    {
      var response = await client.GetAsync($"{origin}/{destiny}");
      if (!response.IsSuccessStatusCode)
      {
        return (0, $"Erro de requisição [{response.StatusCode}]. Verifique a entrada e tente novamente.");
      }

      var data = await response.Content.ReadAsStringAsync();
      double rate;
      var success = new JsonFieldExtractor(data).GetFieldDouble("conversion_rate", out rate);
      if (!success)
      {
        return (0, "Erro ao extrair a taxa de conversão da resposta.");
      }

      return (rate, null);
    }
    catch (Exception)
    {
      return (0, "Erro interno do servidor.");
    }
  }
}
