namespace Poligono.Tests;

using DesafiosCSharp.Projeto_4;
using DesafiosCSharp.Projeto_2;

public class TestPoligono
{
    private void AddVertices(Vertice[] vertices, int qtd)
    {
        var random = new Random();
        for (int i = 0; i < qtd; i++)
        {
            vertices[i] = new Vertice(random.NextDouble(), random.NextDouble());
        }
    }

    [Fact]
    public void TestEmptyInitialization()
    {
        Assert.Throws<ArgumentException>(() => new Poligono());
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    public void TestLessThanThreeVertices(int qtd)
    {
        Vertice[] vertices = new Vertice[qtd];

        AddVertices(vertices, qtd);

        Assert.Throws<ArgumentException>(() => new Poligono(vertices));
    }

    [Fact]
    public void TestThreeOrMoreVertices()
    {
        int qtd = new Random().Next(3, 10);

        Vertice[] vertices = new Vertice[qtd];
        AddVertices(vertices, qtd);

        new Poligono(vertices);
        Assert.True(true);
    }

    [Fact]
    public void TestQuantidade()
    {
        int qtd = new Random().Next(3, 10);

        Vertice[] vertices = new Vertice[qtd];
        AddVertices(vertices, qtd);

        Poligono poligono = new Poligono(vertices);
        Assert.Equal(qtd, poligono.Quantidade);
    }

    [Fact]
    public void TestAddVerticeWithAlreadyAddedVertice()
    {
        var random = new Random();
        int qtd = random.Next(3, 10) + 1;
        Vertice[] vertices = new Vertice[qtd];

        AddVertices(vertices, qtd - 1);

        Vertice v = new Vertice(random.NextDouble(), random.NextDouble());
        vertices[qtd - 1] = v;

        Poligono poligono = new Poligono(vertices);

        Assert.False(poligono.AddVertice(v));
        Assert.Equal(qtd, poligono.Quantidade);
    }

    [Fact]
    public void TestAddVerticeWithNewVertice()
    {
        var random = new Random();
        int qtd = random.Next(3, 10);
        Vertice[] vertices = new Vertice[qtd];

        AddVertices(vertices, qtd);

        Poligono poligono = new Poligono(vertices);

        Vertice v = new Vertice(random.NextDouble(), random.NextDouble());
        Assert.True(poligono.AddVertice(v));
        Assert.Equal(qtd + 1, poligono.Quantidade);
    }

    [Fact]
    public void TestRemoveVerticeWithThreeVertices()
    {
        Vertice[] vertices = new Vertice[3];

        AddVertices(vertices, 2);

        var random = new Random();
        Vertice v = new Vertice(random.NextDouble(), random.NextDouble());
        vertices[2] = v;

        Poligono poligono = new Poligono(vertices);

        Assert.Throws<Exception>(() => poligono.RemoveVertice(v));
    }

    [Fact]
    public void TestRemoveVerticeWithMoreThanThreeVertice()
    {
        var random = new Random();
        int qtd = random.Next(4, 10) + 1;
        Vertice[] vertices = new Vertice[qtd];

        AddVertices(vertices, qtd - 1);
        Vertice v = new Vertice(random.NextDouble(), random.NextDouble());
        vertices[qtd - 1] = v;

        Poligono poligono = new Poligono(vertices);

        poligono.RemoveVertice(v);
        Assert.Equal(qtd - 1, poligono.Quantidade);
    }

    [Fact]
    public void TestPerimetro()
    {
        Poligono poligono = new Poligono(
            new Vertice(0.0, 0.0),
            new Vertice(4.0, 0.0),
            new Vertice(4.0, 3.0),
            new Vertice(0.0, 3.0)
        );

        Assert.Equal(14.00, poligono.Perimetro(), 2);
    }
}
