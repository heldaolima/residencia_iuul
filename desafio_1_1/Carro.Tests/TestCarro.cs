namespace Carro.Tests;
using DesafiosCSharp.Projeto_9;

public class TestCarro
{
    [Theory]
    [InlineData(0.5, 140)]
    [InlineData(1.0, 140)]
    [InlineData(1.4, 160)]
    [InlineData(1.6, 160)]
    [InlineData(1.7, 180)]
    [InlineData(2.0, 180)]
    [InlineData(2.5, 220)]
    public void TestVelocidadeMaxima(double cilindrada, uint expected)
    {
        Motor motor = new Motor(cilindrada);
        Carro carro = new Carro("placa", "modelo", motor);
        Assert.Equal(expected, carro.VelocidadeMaxima);
    }

    [Fact]
    public void TestSameMotorForTwoCars()
    {
        Motor motor = new Motor(1.0);
        Carro carro = new Carro("Placa", "Modelo", motor);
        Assert.Throws<InvalidOperationException>(() => new Carro("placa", "modelo", motor));
    }

    [Fact]
    public void TestSameMotorForTwoCarsSwitch()
    {
        Motor mA = new Motor(1.0);
        Motor mB = new Motor(2.0);

        Carro cA = new Carro("Placa", "Modelo", mA);
        Assert.Equal(cA, mA.CarroAssociado);
        Assert.Equal(mA, cA.Motor);

        Carro cB = new Carro("Placa", "Modelo", mB);
        Assert.Equal(cB, mB.CarroAssociado);
        Assert.Equal(mB, cB.Motor);

        Assert.Throws<InvalidOperationException>(() => cA.TrocarMotor(mB));
        Assert.Equal(mA, cA.Motor);

        Assert.Throws<InvalidOperationException>(() => cB.TrocarMotor(mA));
        Assert.Equal(mB, cB.Motor);
    }

    [Fact]
    public void TestSwitchMotors()
    {
        Motor mA = new Motor(1.0);
        Carro carro = new Carro("Placa", "Modelo", mA);

        Motor mB = new Motor(2.0);
        carro.TrocarMotor(mB);

        Assert.Equal(mB, carro.Motor);
        Assert.Null(mA.CarroAssociado);
    }
}
