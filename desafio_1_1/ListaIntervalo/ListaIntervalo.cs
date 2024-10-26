namespace DesafiosCSharp.Projeto_6;
using DesafiosCSharp.Projeto_5;
using System.Collections.Immutable;

public class ListaIntervalo
{
  private List<Intervalo> intervalos;
  public ListaIntervalo(params Intervalo[] intervalos)
  {
    this.intervalos = new List<Intervalo>(intervalos);
  }

  public bool Add(Intervalo intervalo)
  {
    if (intervalos.Exists((i) => i.TemIntersecao(intervalo)))
    {
      return false;
    }

    intervalos.Add(intervalo);
    return true;
  }

  public ImmutableList<Intervalo> Intervalos =>
    ImmutableList.Create<Intervalo>(intervalos.ToArray());
}
