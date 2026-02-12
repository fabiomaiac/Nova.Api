using Nova.Domain;
using Nova.Domain.Interfaces.Services;
using Nova.Domain.Interfaces.Repositories;

namespace Nova.Application;

public class ContaService : IContaService
{
    private readonly IContaBancariaRepository _repository;

    public ContaService(IContaBancariaRepository repository)
    {
        _repository = repository;
    }

    public async Task<ContaBancaria?> ObterPorNumero(int numeroConta)
    {
        return await _repository.ObterPorNumero(numeroConta);
    }

    public async Task<List<ContaBancaria>> Listar()
    {
        return await _repository.Listar();
    }

    public async Task CriarConta(int numeroConta, string titular, decimal saldoInicial)
    {
        var contaExistente = await _repository.ObterPorNumero(numeroConta);

        if (contaExistente != null)
            throw new Exception("Já existe uma conta com esse número.");

        var conta = new ContaBancaria(numeroConta, titular, saldoInicial);

        await _repository.Adicionar(conta);
    }

    public async Task Depositar(int numeroConta, decimal valor)
    {
        var conta = await _repository.ObterPorNumero(numeroConta);

        if (conta == null)
            throw new Exception("Conta não encontrada.");

        conta.Depositar(valor);

        await _repository.Atualizar(conta);
    }

    public async Task Sacar(int numeroConta, decimal valor)
    {
        var conta = await _repository.ObterPorNumero(numeroConta);

        if (conta == null)
            throw new Exception("Conta não encontrada.");

        conta.Sacar(valor);

        await _repository.Atualizar(conta);
    }

    public async Task Remover(int numeroConta)
    {
        await _repository.Remover(numeroConta);
    }
}
