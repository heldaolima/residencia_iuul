namespace DesafiosCSharp.Projeto_1;

public class Piramide
{
  public int N { get; private set; }
  public Piramide(int _N)
  {
    if (_N < 1)
    {
      throw new ArgumentException("N deve ser >= 1.");
    }
    N = _N;
  }

  private void DesenhaEspacos(int i)
  {
    for (int j = 0; j < N - i; j++)
    {
      Console.Write(" ");
    }
  }

  public void Desenha()
  {
    for (int i = 1; i <= N; i++)
    {
      DesenhaEspacos(i);

      for (int j = 1; j <= i; j++)
      {
        Console.Write($"{j}");
      }

      for (int j = i - 1; j >= 1; j--)
      {
        Console.Write($"{j}");
      }

      Console.WriteLine();
    }
  }
}
