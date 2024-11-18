namespace Conversor.Infra.Request;

using Infra.Env;
using System.Text.Json;

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
      var (rate, success) = ExtractConversionRate(data);
      if (!success)
        return (0, "Erro ao extrair a taxa de conversão.");
      return (rate, null);
    }
    catch (Exception)
    {
      return (0, "Erro interno do servidor.");
    }
  }

  private (double, bool) ExtractConversionRate(string content)
  {
    try
    {
      var jsonDoc = JsonDocument.Parse(content);
      var root = jsonDoc.RootElement;
      if (root.TryGetProperty("conversion_rate", out JsonElement rateElement))
      {
        return (rateElement.GetDouble(), true);
      }
      else
      {
        return (0, false);
      }
    }
    catch (JsonException)
    {
      return (0, false);
    }
  }
}
