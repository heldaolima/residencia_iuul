namespace DesafiosCSharp.Projeto_9;

public class Motor
{
  public double Cilindrada { get; }
  public Carro? CarroAssociado { get; private set; }

  public Motor(double cilindrada)
  {
    Cilindrada = cilindrada;
    CarroAssociado = null;
  }

  public void AssociarCarro(Carro carro)
  {
    if (CarroAssociado != null && CarroAssociado != carro)
    {
      throw new InvalidOperationException("O motor já está associado a um carro.");
    }
    CarroAssociado = carro;
  }
}
