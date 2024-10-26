namespace Vertice.Tests;
using DesafiosCSharp.Projeto_2;

public class TestVertice
{
    [Fact]
    public void TestMove()
    {
        var random = new Random();
        Vertice v = new Vertice(random.NextDouble(), random.NextDouble());

        double newX = random.NextDouble();
        double newY = random.NextDouble();

        Assert.NotEqual(newX, v.X);
        Assert.NotEqual(newY, v.Y);

        v.Move(newX, newY);
        Assert.Equal(newX, v.X);
        Assert.Equal(newY, v.Y);
    }

    [Theory]
    [InlineData(1.0, 2.0, 4.0, 6.0, 5.0)]
    [InlineData(0.0, 0.0, 3.0, 4.0, 5.0)]
    [InlineData(2.0, 3.0, 2.0, 3.0, 0.0)]
    [InlineData(1000, 1000, 2000, 2000, 1414.21)]
    public void TestDistancia(double x1, double y1, double x2, double y2, double expected)
    {
        Vertice vA = new Vertice(x1, y1);
        Vertice vB = new Vertice(x2, y2);

        Assert.Equal(expected, vA.Distancia(vB), 2);
    }

    [Fact]
    public void TestEquality()
    {
        var random = new Random();

        double x = random.NextDouble();
        double y = random.NextDouble();

        Vertice v1 = new Vertice(x, y);
        Vertice v2 = new Vertice(x, y);

        Assert.True(v1 == v2);
        Assert.False(v1 != v2);
    }

    [Fact]
    public void TestInequality()
    {
        var random = new Random();

        Vertice v1 = new Vertice(random.NextDouble(), random.NextDouble());
        Vertice v2 = new Vertice(random.NextDouble(), random.NextDouble());

        Assert.True(v1 != v2);
        Assert.False(v1 == v2);

        Vertice v1Ref = v1;
        Assert.True(v1Ref == v1);
    }
}
