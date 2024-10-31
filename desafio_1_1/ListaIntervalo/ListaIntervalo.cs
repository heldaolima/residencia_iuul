namespace DesafiosCSharp.Projeto_6;
using DesafiosCSharp.Projeto_5;
using System.Collections.Immutable;

public class ListaIntervalo
{
  private List<Intervalo> intervalos;
  private bool modified = true;

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
    modified = true;
    return true;
  }

  public ImmutableList<Intervalo> Intervalos
  {
    get
    {
      if (modified)
      {
        intervalos.Sort((a, b) => a.Inicial.CompareTo(b.Inicial));
        modified = false;
      }

      return ImmutableList.Create<Intervalo>(intervalos.ToArray()); // faltou ordernar
    }
  }
}
