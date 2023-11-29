using Microsoft.AspNetCore.Mvc;
using api.Models;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class EstacionamentoController : ControllerBase
{
    private static readonly Estacionamento _estacionamento = new (100);
    
    private readonly ILogger<EstacionamentoController> _logger;

    public EstacionamentoController(ILogger<EstacionamentoController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult EstacionamentoCheio()
    {

        bool estacionamentoCheio;
        
        lock (_estacionamento)
        {
            estacionamentoCheio = _estacionamento.EstacionamentoCheio();
        }

        _logger.LogInformation($"Estacionamento cheio? -: {_estacionamento.EstacionamentoCheio()} | " +
                               $"{DateTime.Now:HH:mm:ss}");

        return Ok(estacionamentoCheio);
    }
}