namespace Conversor.Infra.Request;

using Infra.Env;

public class RequestHandler
{
  private String ApiKey;

  public RequestHandler()
  {
    var key = new EnvHandler().GetApiKey();
    if (key is null)
    {
      throw new Exception("Erro: chave de API não encontrada.");
    }

    ApiKey = key;
  }
}
