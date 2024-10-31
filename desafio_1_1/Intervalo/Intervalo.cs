namespace DesafiosCSharp.Projeto_5;

public class Intervalo : IEquatable<Intervalo>
{
  private DateTime inicial, final;
  public Intervalo(DateTime inicial, DateTime final)
  {
    if (inicial > final)
    {
      throw new ArgumentException("A data inicial não pode ser maior que a data final.");
    }

    this.inicial = inicial;
    this.final = final;
  }

  public TimeSpan Duracao => final.Subtract(inicial);
  public DateTime Inicial => inicial;
  public DateTime Final => final;

  public bool TemIntersecao(Intervalo intervalo)
  {
    return inicial < intervalo.Final && intervalo.Inicial < final;
  }

  public static bool operator ==(Intervalo a, Intervalo b)
  {
    if (ReferenceEquals(a, b))
      return true;

    if (a is null || b is null)
      return false;

    return a.Equals(b);
  }

  public static bool operator !=(Intervalo a, Intervalo b)
  {
    return !(a == b);
  }

  public override int GetHashCode()
  {
    return HashCode.Combine(inicial, final);
  }

  public override bool Equals(object? obj)
  {
    if (obj is Intervalo i)
    {
      return Equals(i);
    }

    return false;
  }

  public bool Equals(Intervalo? other)
  {
    if (other is null) return false;

    return inicial == other.inicial && final == other.final;
  }
}
