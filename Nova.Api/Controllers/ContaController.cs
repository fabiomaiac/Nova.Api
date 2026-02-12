using Microsoft.AspNetCore.Mvc;
using Nova.Domain.Dtos;
using Nova.Domain;
using Nova.Domain.Interfaces.Services;

namespace Nova.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContaController : ControllerBase
{
    private readonly IContaService _service;

    public ContaController(IContaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<ContaBancaria>>> Listar()
    {
        var contas = await _service.Listar();
        return Ok(contas);
    }

    [HttpGet("{numeroConta}")]
    public async Task<ActionResult<ContaBancaria>> Obter(int numeroConta)
    {
        var conta = await _service.ObterPorNumero(numeroConta);

        if (conta == null)
            return NotFound("Conta não encontrada.");

        return Ok(conta);
    }

    [HttpPost]
    public async Task<ActionResult> Criar([FromBody] CriarContaRequest request)
    {
        try
        {
            await _service.CriarConta(request.NumeroConta, request.Titular, request.SaldoInicial);
            return Created("", "Conta criada com sucesso.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("depositar")]
    public async Task<ActionResult> Depositar([FromBody] OperacaoRequest request)
    {
        try
        {
            await _service.Depositar(request.NumeroConta, request.Valor);
            return Ok("Depósito realizado com sucesso.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("sacar")]
    public async Task<ActionResult> Sacar([FromBody] OperacaoRequest request)
    {
        try
        {
            await _service.Sacar(request.NumeroConta, request.Valor);
            return Ok("Saque realizado com sucesso.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{numeroConta}")]
    public async Task<ActionResult> Remover(int numeroConta)
    {
        await _service.Remover(numeroConta);
        return Ok("Conta removida com sucesso.");
    }
}
