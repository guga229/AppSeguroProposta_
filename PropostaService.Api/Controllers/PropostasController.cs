using Microsoft.AspNetCore.Mvc;
using PropostaService.Application.Commands;
using PropostaService.Application.CommandsHandlers;
using PropostaService.Domain.Enums;
using PropostaService.Domain.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class PropostasController : ControllerBase
{
    private readonly CriarPropostaHandler _criarHandler;
    private readonly AlterarStatusHandler _statusHandler;
    private readonly IPropostaRepository _repository;

    public PropostasController(
        CriarPropostaHandler criarHandler,
        AlterarStatusHandler statusHandler,
        IPropostaRepository repository)
    {
        _criarHandler = criarHandler;
        _statusHandler = statusHandler;
        _repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] CriarPropostaCommand command)
    {
        var id = await _criarHandler.HandleAsync(command);
        return CreatedAtAction(nameof(ObterPorId), new { id }, null);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorId(Guid id)
    {
        var proposta = await _repository.ObterPorIdAsync(id);
        return proposta == null ? NotFound() : Ok(proposta);
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var propostas = await _repository.ListarAsync();
        return Ok(propostas);
    }

    [HttpPut("{id}/status")]
    public async Task<IActionResult> AlterarStatus(Guid id, [FromBody] PropostaStatus novoStatus)
    {
        await _statusHandler.HandleAsync(id, novoStatus);
        return NoContent();
    }
}
