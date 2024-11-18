namespace Conversor.Infra.Env;

using DotNetEnv;

public class EnvHandler
{
  public EnvHandler()
  {
    Env.Load();
  }

  public String? GetApiKey()
  {
    return Env.GetString("API_KEY");
  }
}
