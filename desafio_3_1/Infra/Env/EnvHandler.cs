namespace DentalOffice.Infra.Env;

using DotNetEnv;

public class EnvHandler
{
  public EnvHandler()
  {
    Env.Load();
  }

  public String GetVar(string var)
  {
    return Env.GetString(var);
  }
}
