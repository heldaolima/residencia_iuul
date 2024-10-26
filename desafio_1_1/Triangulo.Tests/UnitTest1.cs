namespace Triangulo.Tests;
using DesafiosCSharp.Projeto_2;
using DesafiosCSharp.Projeto_3;

public class TestTriangulo
{
    [Fact]
    public void TestInvalidVertices()
    {
        Vertice a = new Vertice(0.0, 0.0);
        Vertice b = new Vertice(1.0, 1.0);
        Vertice c = new Vertice(3.0, 3.0);

        Assert.Throws<ArgumentException>(() => new Triangulo(a, b, c));
    }

    [Fact]
    public void TestValidVerticesEquilatero()
    {
        Vertice a = new Vertice(0.0, 0.0);
        Vertice b = new Vertice(4.0, 0.0);
        Vertice c = new Vertice(2.0, 2 * Math.Sqrt(3));

        Triangulo t = new Triangulo(a, b, c);
        Assert.Equal(Triangulo.TipoTriangulo.Equilatero, t.Tipo);
    }

    [Fact]
    public void TestValidVerticesIsosceles()
    {
        Vertice a = new Vertice(0.0, 0.0);
        Vertice b = new Vertice(2.0, 0.0);
        Vertice c = new Vertice(1.0, 2.0);

        Triangulo t = new Triangulo(a, b, c);
        Assert.Equal(Triangulo.TipoTriangulo.Isosceles, t.Tipo);
    }

    [Fact]
    public void TestValidVerticesEscaleno()
    {
        Vertice a = new Vertice(0.0, 0.0);
        Vertice b = new Vertice(3.0, 0.0);
        Vertice c = new Vertice(2.0, 4.0);

        Triangulo t = new Triangulo(a, b, c);
        Assert.Equal(Triangulo.TipoTriangulo.Escaleno, t.Tipo);
    }

    [Fact]
    public void TestPerimetro()
    {
        Vertice a = new Vertice(0.0, 0.0);
        Vertice b = new Vertice(3.0, 0.0);
        Vertice c = new Vertice(0.0, 4.0);

        Triangulo triangulo = new Triangulo(a, b, c);
        Assert.Equal(12.00, triangulo.Perimetro, 2);
    }

    [Fact]
    public void TestArea()
    {
        Vertice a = new Vertice(0.0, 0.0);
        Vertice b = new Vertice(3.0, 0.0);
        Vertice c = new Vertice(0.0, 4.0);

        Triangulo triangulo = new Triangulo(a, b, c);
        Assert.Equal(6.00, triangulo.Area, 2);
    }

    [Fact]
    public void TestValueEquality()
    {
        Vertice a = new Vertice(0.0, 0.0);
        Vertice b = new Vertice(3.0, 0.0);
        Vertice c = new Vertice(0.0, 4.0);

        Triangulo t1 = new Triangulo(a, b, c);
        Triangulo t2 = new Triangulo(a, b, c);

        Assert.True(t1 == t2);
        Assert.False(t1 != t2);
    }

    [Fact]
    public void TestReferenceEquality() {
        Vertice a = new Vertice(0.0, 0.0);
        Vertice b = new Vertice(3.0, 0.0);
        Vertice c = new Vertice(0.0, 4.0);

        Triangulo t1 = new Triangulo(a, b, c);
        Triangulo copy = t1;

        Assert.True(t1 == copy);
        Assert.False(t1 != copy);
    }
}
