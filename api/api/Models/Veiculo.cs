using api.Models.interfaces;

namespace api.Models;

public class Veiculo : IVeiculo
{
    public Veiculo(string tipo)
    {
        Tipo = tipo;
    }
    public string Tipo { get; set; }
}