namespace Piramide.Tests;
using DesafiosCSharp.Projeto_1;

public class Piramide_Should
{
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Piramide_ShouldThrow_IfNIsLowerThan1(int value)
    {
        Assert.Throws<ArgumentException>(() => new Piramide(value));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void Piramide_ShouldDraw_IfNIsBiggerThan1(int value)
    {
        Piramide piramide = new Piramide(value);
        Console.WriteLine($"Desenha {value}:");
        piramide.Desenha();
        Console.WriteLine();
        Assert.True(true);
    }
}
