namespace DesafiosCSharp.Projeto_1;

public class Vertice
{
  private double _X, _Y;

  public Vertice(double x, double y)
  {
    _X = x;
    _Y = y;
  }

  public double X => _X;
  public double Y => _Y;

  public double Distancia(Vertice v)
  {
    double deltaX = v.X - _X;
    double deltaY = v.Y - _Y;
    return Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
  }

  public void Move(double x, double y)
  {
    _X = x;
    _Y = y;
  }

  public static bool operator ==(Vertice v1, Vertice v2)
  {
    if (ReferenceEquals(v1, v2))
      return true;

    return v1.X == v2.X && v1.Y == v2.Y;
  }

  public static bool operator !=(Vertice v1, Vertice v2)
  {
    return !(v1 == v2);
  }

  public override bool Equals(object? obj) => obj is Vertice && Equals(obj as Vertice);

  public override int GetHashCode()
  {
    return _X.GetHashCode() ^ _Y.GetHashCode();
  }
}
