using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using APIHorario.Models;

namespace APIHorario.Controllers;

[ApiController]
[Route("[controller]")]
public class HorarioAtualController : ControllerBase
{
    private readonly ILogger<HorarioAtualController> _logger;

    public HorarioAtualController(ILogger<HorarioAtualController> logger)
    {
        _logger = logger;
    }

    [HttpGet("nocache")]
    public Resultado GetNoCache()
    {
        var result = new Resultado() { Mensagem = "Teste sem cache" };
        _logger.LogInformation($"{result.HorarioAtual} {result.Mensagem}");
        return result;
    }

    [HttpGet("cache")]
    [OutputCache( Duration = 5)]
    public Resultado GetCache()
    {
        var result = new Resultado() { Mensagem = "Teste com cache" };
        _logger.LogInformation($"{result.HorarioAtual} {result.Mensagem}");
        return result;
    }

    [HttpGet("cachequerystring")]
    [OutputCache(Duration = 15, VaryByQueryKeys = new string[] { "valorTeste" })]
    public Resultado GetCacheQueryString(string valorTeste)
    {
        var result = new Resultado()
        {
            Mensagem = $"Teste com cache | Query string: {nameof(valorTeste)} = {valorTeste}"
        };
        _logger.LogInformation($"{result.HorarioAtual} {result.Mensagem}");
        return result;
    }
}