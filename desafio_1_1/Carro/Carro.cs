﻿namespace DesafiosCSharp.Projeto_9;

public class Carro
{
  public String Placa { get; }
  public String Modelo { get; }
  public uint VelocidadeMaxima { get; private set; }
  private Motor motor;

  public Motor Motor
  {
    get => motor;
    private set => SetMotor(value);
  }

  public Carro(String placa, String modelo, Motor motor)
  {
    Placa = placa;
    Modelo = modelo;
    Motor = motor;
  }

  public void TrocarMotor(Motor motor)
  {
    motor.VerificarCarro(this);
    this.motor.DesassociarCarro();
    Motor = motor;
  }

  private void SetMotor(Motor motor)
  {
    motor.AssociarCarro(this);

    this.motor = motor;
    VelocidadeMaxima = this.motor.Cilindrada switch
    {
      <= 1.0 => 140,
      > 1.0 and <= 1.6 => 160,
      > 1.6 and <= 2.0 => 180,
      _ => 220,
    };
  }
}
