namespace api;

using Models;
using System.Collections.Generic;

public class Estacionamento
{
    // Número total de vagas no estacionamento
    private int _totalVagas;

    // Número de vagas ocupadas por cada tipo de veículo
    private int _vagasMoto;
    private int _vagasCarro;
    private int _vagasVan;

    // Lista de veículos estacionados
    private List<Veiculo> _veiculosEstacionados;
    
    // Construtor que inicializa o estacionamento com o número total de vagas
    public Estacionamento(int totalVagas)
    {
        _totalVagas = totalVagas;
        _vagasMoto = 0;
        _vagasCarro = 0;
        _vagasVan = 0;
        _veiculosEstacionados = new List<Veiculo>();
    }

    // Adiciona um veículo ao estacionamento
    public string EstacionarVeiculo(Veiculo veiculo)
    {
        if (VeiculoPodeEstacionar(veiculo))
        {
            _veiculosEstacionados.Add(veiculo);
            AtualizarContagemVagas(veiculo, true);
            return $"{veiculo.Tipo} estacionado com sucesso!";
        }
        return $"Não há vagas disponíveis para {veiculo.Tipo}.";
    }

    // Remove um veículo do estacionamento
    public string RetirarVeiculo(Veiculo veiculo)
    {
        if (_veiculosEstacionados.Contains(veiculo))
        {
            _veiculosEstacionados.Remove(veiculo);
            AtualizarContagemVagas(veiculo, false);
            return $"{veiculo.Tipo} retirado do estacionamento.";
        } 
        return $"{veiculo.Tipo} não encontrado no estacionamento.";
    }

    // Verifica se um veículo pode estacionar com base no tipo e disponibilidade de vagas
    private bool VeiculoPodeEstacionar(Veiculo veiculo)
    {
        if (veiculo is Moto)
        {
            return _vagasMoto < _totalVagas;
        }
        if (veiculo is Carro)
        {
            return _vagasCarro < _totalVagas;
        }
        if (veiculo is Van)
        {
            return _vagasCarro + 3 <= _totalVagas;
        }
        return false;
    }

    // Atualiza a contagem de vagas ocupadas com base no tipo de veículo e na operação de estacionar ou retirar
    private void AtualizarContagemVagas(Veiculo veiculo, bool estacionar)
    {
        if (veiculo is Moto)
        {
            _vagasMoto += estacionar ? 1 : -1;
        }
        else if (veiculo is Carro)
        {
            _vagasCarro += estacionar ? 1 : -1;
        }
        else if (veiculo is Van)
        {
            _vagasVan += estacionar ? 3 : -3;
        }
    }

    // Métodos para obter informações sobre o estado do estacionamento
    public int VagasRestantes()
    {
        return _totalVagas - _veiculosEstacionados.Count;
    }

    public int VagasTotais()
    {
        return _totalVagas;
    }

    public bool EstacionamentoCheio()
    {
        return _veiculosEstacionados.Count == _totalVagas;
    }

    public bool EstacionamentoVazio()
    {
        return _veiculosEstacionados.Count == 0;
    }

    public int VagasOcupadasPorVan()
    {
        return _vagasVan;
    }
}