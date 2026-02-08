using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nova.Api.Dtos;
using Nova.Application;
using Nova.Domain;


namespace NovaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContaController : ControllerBase
    {
        private readonly ContaService _contaService;

        public ContaController(ContaService contaService)
        {
            _contaService = contaService;
        }

        [HttpPost("depositar")]
        public IActionResult Depositar([FromBody] DepositoRequest request)
        {
            try
            {
                var conta = _contaService.Depositar(request.NumeroConta, request.Valor);
                return Ok(Mapear(conta));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ErrorResponse { Mensagem = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{numeroConta}")]
        public IActionResult ObterConta(int numeroConta)
        {
            var conta = _contaService.ObterConta(numeroConta);

            if (conta == null)
                return NotFound("Conta não encontrada");

            return Ok(Mapear(conta));
        }

        [HttpPost("sacar")]
        public IActionResult Sacar([FromBody] SaqueRequest request)
        {
            try
            {
                var conta = _contaService.Sacar(request.NumeroConta, request.Valor);
                return Ok(Mapear(conta));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ErrorResponse { Mensagem = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new ErrorResponse { Mensagem = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult ListarContas()
        {
            var contas = _contaService.ListarContas();

            var response = contas.Select(c => Mapear(c));

            return Ok(response);
        }

        [HttpPost]
        public IActionResult CriarConta(CriarContaRequest request)
        {
            try
            {
                var conta = _contaService.CriarConta(
                    request.NumeroConta,
                    request.Titular,
                    request.SaldoInicial
                );

                return CreatedAtAction(
                    nameof(ObterConta),
                    new { numeroConta = conta.NumeroConta },
                    Mapear(conta)
                );
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Mensagem = ex.Message });
            }
        }

        [HttpDelete("{numeroConta}")]
        public IActionResult RemoverConta(int numeroConta)
        {
            try
            {
                _contaService.RemoverConta(numeroConta);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new ErrorResponse { Mensagem = ex.Message });
            }
        }

        private static ContaResponse Mapear(ContaBancaria conta)
        {
            return new ContaResponse
            {
                NumeroConta = conta.NumeroConta,
                Titular = conta.Titular,
                Saldo = conta.Saldo
            };
        }
    }
}