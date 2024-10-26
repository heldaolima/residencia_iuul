namespace Intervalo.Tests;
using DesafiosCSharp.Projeto_5;

public class TestIntervalo
{
    [Fact]
    public void TestInvalidDates()
    {
        DateTime inicial = new DateTime(2024, 10, 25);
        DateTime final = new DateTime(2023, 10, 25);

        Assert.Throws<ArgumentException>(() => new Intervalo(inicial, final));
    }

    [Fact]
    public void TestValidDates()
    {
        DateTime inicial = new DateTime(2023, 10, 25);
        DateTime final = new DateTime(2024, 10, 25);

        Intervalo intervalo = new Intervalo(inicial, final);
    }

    [Fact]
    public void TestDuracao()
    {
        DateTime inicial = new DateTime(2023, 10, 25);
        DateTime final = new DateTime(2024, 10, 25);

        Intervalo intervalo = new Intervalo(inicial, final);
        Assert.Equal(final.Subtract(inicial), intervalo.Duracao);
    }

    [Fact]
    public void TestTemIntersecaoFalse()
    {
        Intervalo intervaloA = new Intervalo(
            new DateTime(2024, 10, 25, 8, 0, 0),
            new DateTime(2024, 10, 25, 10, 0, 0)
        );

        Intervalo intervaloB = new Intervalo(
            new DateTime(2024, 10, 25, 11, 0, 0),
            new DateTime(2024, 10, 25, 12, 0, 0)
        );

        Assert.False(intervaloA.TemIntersecao(intervaloB));
        Assert.False(intervaloB.TemIntersecao(intervaloA));
    }

    [Fact]
    public void TestTemIntersecaoTrue()
    {
        Intervalo intervaloA = new Intervalo(
            new DateTime(2024, 10, 25, 10, 0, 0),
            new DateTime(2024, 10, 25, 12, 0, 0)
        );

        Intervalo intervaloB = new Intervalo(
            new DateTime(2024, 10, 25, 11, 0, 0),
            new DateTime(2024, 10, 25, 13, 0, 0)
        );

        Assert.True(intervaloA.TemIntersecao(intervaloB));
        Assert.True(intervaloB.TemIntersecao(intervaloA));
    }

    [Fact]
    public void TestValueEquality()
    {
        DateTime inicial = new DateTime(2024, 10, 25, 10, 0, 0);
        DateTime final = new DateTime(2024, 10, 25, 12, 0, 0);

        Intervalo a = new Intervalo(inicial, final);
        Intervalo b = new Intervalo(inicial, final);

        Assert.True(a == b);
        Assert.False(a != b);
    }

    [Fact]
    public void TestReferenceEquality()
    {
        DateTime inicial = new DateTime(2024, 10, 25, 10, 0, 0);
        DateTime final = new DateTime(2024, 10, 25, 12, 0, 0);

        Intervalo intervalo = new Intervalo(inicial, final);
        Intervalo copy = intervalo;

        Assert.True(intervalo == copy);
        Assert.False(intervalo != copy);
    }

}
