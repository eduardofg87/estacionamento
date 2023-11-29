namespace api.Models;

public class Van : Veiculo
{
    public Van(string tipo = "Van") : base(tipo)
    {
        Tipo = tipo;
    }
}