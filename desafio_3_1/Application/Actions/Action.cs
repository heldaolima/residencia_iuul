namespace DentalOffice.Application.Actions;

public interface Action
{
  public abstract Task<ActionOptions> Run();
}
