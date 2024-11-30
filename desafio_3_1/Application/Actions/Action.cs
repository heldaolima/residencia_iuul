namespace DentalOffice.Application.Actions;

interface Action
{
  public abstract static Task<ActionOptions> Run();
}
