using System;

class Movimentacao
{
    public string Data { get; private set; }
    public string Tipo { get; private set; }
    public double Valor { get; private set; }

    public Movimentacao() { }

    public Movimentacao(string data, string tipo, double valor)
    {
        Data = data;
        Tipo = tipo;
        Valor = valor;
    }

    public void calcular_despesa()
    {
        Console.WriteLine("Calculando despesas...");
    }
}