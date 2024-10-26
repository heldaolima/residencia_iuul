namespace ListaIntervalo.Tests;

using DesafiosCSharp.Projeto_5;
using DesafiosCSharp.Projeto_6;

using System.Collections.Immutable;

public class TestIntervalo
{
    [Fact]
    public void TestDoNotAdd()
    {
        ListaIntervalo lista = new ListaIntervalo(
            new Intervalo(
                new DateTime(2024, 10, 25, 10, 0, 0),
                new DateTime(2024, 10, 25, 12, 0, 0)
            )
        );

        Assert.False(lista.Add(
            new Intervalo(
                new DateTime(2024, 10, 25, 11, 0, 0),
                new DateTime(2024, 10, 25, 13, 0, 0)
            )
        ));

    }

    [Fact]
    public void TestAdd()
    {
        ListaIntervalo lista = new ListaIntervalo(
            new Intervalo(
                new DateTime(2024, 10, 25, 8, 0, 0),
                new DateTime(2024, 10, 25, 10, 0, 0)
            )
        );

        Assert.True(lista.Add(
            new Intervalo(
                new DateTime(2024, 10, 25, 11, 0, 0),
                new DateTime(2024, 10, 25, 12, 0, 0)
            )
        ));
    }

    [Fact]
    void TestIntervalosProperty()
    {
        ListaIntervalo lista = new ListaIntervalo(
            new Intervalo(
                new DateTime(2024, 10, 25, 8, 0, 0),
                new DateTime(2024, 10, 25, 10, 0, 0)
            )
        );

        Assert.IsType<ImmutableList<Intervalo>>(lista.Intervalos);
    }
}
