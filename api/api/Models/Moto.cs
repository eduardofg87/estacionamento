namespace api.Models;

public class Moto : Veiculo
{
    public Moto(string tipo = "Moto") : base(tipo)
    {
        Tipo = tipo;
    }
}