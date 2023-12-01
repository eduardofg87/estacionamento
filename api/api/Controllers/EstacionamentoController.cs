using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Services.interfaces;

namespace api.Controllers;

[ApiController]
[Route("api/v1/estacionamento")]
public class EstacionamentoController : ControllerBase
{
    private readonly IEstacionamentoService _estacionamentoService;
    
    private static readonly Estacionamento _estacionamento = new (100);
    
    private readonly ILogger<EstacionamentoController> _logger;

    public EstacionamentoController(ILogger<EstacionamentoController> logger, IEstacionamentoService estacionamentoService)
    {
        _logger = logger;
        _estacionamentoService = estacionamentoService ?? throw new ArgumentNullException();
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("estacionar-moto")]
    public IActionResult EstacionarMoto()
    {
        try
        {
            bool veiculoEstacionado;
            string msg;
            
            lock (_estacionamento)
            {
                Moto moto = new Moto();
                veiculoEstacionado = _estacionamento.EstacionarVeiculo(moto);
                msg = _estacionamentoService.VarificarSeVeiculoFoiEstacionado(veiculoEstacionado, moto);
            }

            _logger.LogInformation($"Veículo estacionado? -: {msg} | " +
                                   $"{DateTime.Now:HH:mm:ss}");

            return Ok(msg);
        }
        catch (ArgumentException e)
        {
            _logger.LogInformation($"Erro ao estacionar moto -: {e.Message} | " +
                                   $"{DateTime.Now:HH:mm:ss}");
            return BadRequest();
        }
    }
    
    [HttpPost]
    [Route("estacionar-carro")]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult EstacionarCarro()
    {

        try
        {
            bool veiculoEstacionado;
            string msg;
            
            lock (_estacionamento)
            {
                Carro carro = new Carro();
                veiculoEstacionado = _estacionamento.EstacionarVeiculo(carro);
                msg = _estacionamentoService.VarificarSeVeiculoFoiEstacionado(veiculoEstacionado, carro);
            }

            _logger.LogInformation($"Veículo estacionado? -: {msg} | " +
                                   $"{DateTime.Now:HH:mm:ss}");

            return Ok(msg);
        }
        catch (ArgumentException e)
        {
            _logger.LogInformation($"Erro ao estacionar carro -: {e.Message} | " +
                                   $"{DateTime.Now:HH:mm:ss}");
            return BadRequest();
        }
    }
    
    [HttpPost]
    [Route("estacionar-van")]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult EstacionarVan()
    {
        try
        {
            bool veiculoEstacionado;
            string msg;
            
            lock (_estacionamento)
            {
                Van van = new Van();
                veiculoEstacionado = _estacionamento.EstacionarVeiculo(van);
                msg = _estacionamentoService.VarificarSeVeiculoFoiEstacionado(veiculoEstacionado, van);
            }

            _logger.LogInformation($"Veículo estacionado? -: {msg} | " +
                                   $"{DateTime.Now:HH:mm:ss}");

            return Ok(msg);
        }
        catch (ArgumentException e)
        {
            _logger.LogInformation($"Erro ao estacionar van -: {e.Message} | " +
                                   $"{DateTime.Now:HH:mm:ss}");
            return BadRequest();
        }
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("retirar-moto")]
    public IActionResult RetirarMoto()
    {
        try
        {
            bool veiculoRetirado;
            string msg;
        
            lock (_estacionamento)
            {
                Moto moto = new Moto();
                veiculoRetirado = _estacionamento.RetirarVeiculo(moto);
                msg = _estacionamentoService.VarificarSeVeiculoFoiRetirado(veiculoRetirado, moto);
            }

            _logger.LogInformation($"Veículo retirado? -: {msg} | " +
                                   $"{DateTime.Now:HH:mm:ss}");

            return Ok(msg);
        }
        catch (Exception e)
        {
            _logger.LogInformation($"Erro ao retirar moto -: {e.Message} | " +
                                   $"{DateTime.Now:HH:mm:ss}");
            return BadRequest();
        }
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("retirar-carro")]
    public IActionResult RetirarCarro()
    {
        try
        {
            bool veiculoRetirado;
            string msg;
        
            lock (_estacionamento)
            {
                Carro carro = new Carro();
                veiculoRetirado = _estacionamento.RetirarVeiculo(carro);
                msg = _estacionamentoService.VarificarSeVeiculoFoiRetirado(veiculoRetirado, carro);
            }

            _logger.LogInformation($"Veículo retirado? -: {msg} | " +
                                   $"{DateTime.Now:HH:mm:ss}");

            return Ok(msg);
        }
        catch (Exception e)
        {
            _logger.LogInformation($"Erro ao retirar carro -: {e.Message} | " +
                                   $"{DateTime.Now:HH:mm:ss}");
            return BadRequest();
        }
    }
    
    [HttpPost]
    [Route("retirar-van")]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult RetirarVan()
    {
        try
        {
            bool veiculoRetirado;
            string msg;
        
            lock (_estacionamento)
            {
                Van van = new Van();
                veiculoRetirado = _estacionamento.RetirarVeiculo(van);
                msg = _estacionamentoService.VarificarSeVeiculoFoiRetirado(veiculoRetirado, van);
            }

            _logger.LogInformation($"Veículo retirado? -: {msg} | " +
                                   $"{DateTime.Now:HH:mm:ss}");

            return Ok(msg);
        }
        catch (Exception e)
        {
            _logger.LogInformation($"Erro ao retirar van -: {e.Message} | " +
                                   $"{DateTime.Now:HH:mm:ss}");
            return BadRequest();
        }
    }
    
    [HttpGet]
    [Route("vagas-restantes")]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
    public IActionResult VagasRestantes()
    {

        int vagasRestantes;
        
        lock (_estacionamento)
        {
            vagasRestantes = _estacionamento.VagasRestantes();
        }

        _logger.LogInformation($"Vagas restantes: -: {vagasRestantes} | " +
                               $"{DateTime.Now:HH:mm:ss}");

        return Ok(vagasRestantes);
    }
    
    [HttpGet]
    [Route("vagas-totais")]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
    public IActionResult VagasTotais()
    {

        int vagasTotais;
        
        lock (_estacionamento)
        {
            vagasTotais = _estacionamento.VagasTotais();
        }

        _logger.LogInformation($"Vagas totais: -: {vagasTotais} | " +
                               $"{DateTime.Now:HH:mm:ss}");

        return Ok(vagasTotais);
    }
    
    [HttpGet]
    [Route("estacionamento-cheio")]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
    public IActionResult EstacionamentoCheio()
    {

        bool estacionamentoCheio;
        
        lock (_estacionamento)
        {
            estacionamentoCheio = _estacionamento.EstacionamentoCheio();
        }

        _logger.LogInformation($"Estacionamento cheio? -: {estacionamentoCheio} | " +
                               $"{DateTime.Now:HH:mm:ss}");

        return Ok(estacionamentoCheio);
    }
    
    [HttpGet]
    [Route("estacionamento-vazio")]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
    public IActionResult EstacionamentoVazio()
    {

        bool estacionamentoVazio;
        
        lock (_estacionamento)
        {
            estacionamentoVazio = _estacionamento.EstacionamentoVazio();
        }

        _logger.LogInformation($"Estacionamento vazio? -: {estacionamentoVazio} | " +
                               $"{DateTime.Now:HH:mm:ss}");

        return Ok(estacionamentoVazio);
    }
    
    [HttpGet]
    [Route("vagas-ocupadas-por-van")]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
    public IActionResult VagasOcupadasPorVan()
    {

        int vagasOcupadasPorVan;
        
        lock (_estacionamento)
        {
            vagasOcupadasPorVan = _estacionamento.VagasOcupadasPorVan();
        }

        _logger.LogInformation($"Vagas ocupadas por van: {vagasOcupadasPorVan} | " +
                               $"{DateTime.Now:HH:mm:ss}");

        return Ok(vagasOcupadasPorVan);
    }
}