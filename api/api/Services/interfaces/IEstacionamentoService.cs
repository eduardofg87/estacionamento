using api.Models;

namespace api.Services.interfaces;

public interface IEstacionamentoService
{
    string VarificarSeVeiculoFoiRetirado(bool veiculoRetirado, Veiculo veiculo);
    string VarificarSeVeiculoFoiEstacionado(bool veiculoEstacionado, Veiculo veiculo);
}