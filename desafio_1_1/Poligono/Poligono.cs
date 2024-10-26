namespace DesafiosCSharp.Projeto_4;
using DesafiosCSharp.Projeto_2;

public class Poligono
{
  private List<Vertice> vertices;

  public Poligono(params Vertice[] vertices)
  {
    if (vertices.Length < 3)
    {
      throw new ArgumentException("É preciso haver no mínimo 3 vértices.");
    }

    this.vertices = new List<Vertice>(vertices);
  }

  public int Quantidade => vertices.Count;

  public bool AddVertice(Vertice v)
  {
    if (vertices.Contains(v))
    {
      return false;
    }

    vertices.Add(v);
    return true;
  }

  public void RemoveVertice(Vertice v)
  {
    if (vertices.Count - 1 < 3)
    {
      throw new Exception("A remoção deixa o polígono com menos de 3 vértices.");
    }

    vertices.Remove(v);
  }

  public double Perimetro()
  {
    double perimetro = 0.0;
    int n = Quantidade;

    for (int i = 0; i < n; i++)
      perimetro += vertices[i].Distancia(vertices[(i + 1) % n]);

    return perimetro;
  }
}
