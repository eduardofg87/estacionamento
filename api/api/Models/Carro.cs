namespace api.Models;

public class Carro : Veiculo
{
    public Carro(string tipo = "Carro") : base(tipo)
    {
        Tipo = tipo;
    }
}