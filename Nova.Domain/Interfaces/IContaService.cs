using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nova.Domain;

namespace Nova.Domain.Interfaces.Services
{
    public interface IContaService
    {
        Task<ContaBancaria?> ObterPorNumero(int numeroConta);
        Task<List<ContaBancaria>> Listar();
        Task CriarConta(int numeroConta, string titular, decimal saldoInicial);
        Task Depositar(int numeroConta, decimal valor);
        Task Sacar(int numeroConta, decimal valor);
        Task Remover(int numeroConta);
    }
}