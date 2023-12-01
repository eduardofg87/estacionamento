using api.Models;
using api.Services.interfaces;

namespace api.Services;

public class EstacionamentoService : IEstacionamentoService
{
    public string VarificarSeVeiculoFoiRetirado(bool veiculoRetirado, Veiculo veiculo)
    {
        if (veiculoRetirado)
        {
            return $"{veiculo.Tipo} retirado do estacionamento.";
        }
        return $"{veiculo.Tipo} não encontrado no estacionamento.";
    }

    public string VarificarSeVeiculoFoiEstacionado(bool veiculoEstacionado, Veiculo veiculo)
    {
        if (veiculoEstacionado)
        {
            return $"{veiculo.Tipo} estacionado com sucesso!";
        }
        return $"Não há vagas disponíveis para {veiculo.Tipo}.";
    }
}