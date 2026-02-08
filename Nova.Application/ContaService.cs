using Nova.Domain;
using Nova.Domain.Repositories;

namespace Nova.Application;

public class ContaService
{
    private readonly IContaBancariaRepository _repository;
    public ContaService(IContaBancariaRepository repository)
    {
        _repository = repository;
    }

    public ContaBancaria Depositar(int NumeroConta, decimal valor)
    {
        var conta = _repository.ObterPorNumero(NumeroConta);

        if (conta == null)
            throw new InvalidOperationException("Conta não encontrada");

        conta.Depositar(valor);

        _repository.Atualizar(conta);

        return conta;
    }

    public ContaBancaria? ObterConta(int numeroConta)
    {
        return _repository.ObterPorNumero(numeroConta);
    }

    public ContaBancaria Sacar(int numeroConta, decimal valor)
    {
        var conta = _repository.ObterPorNumero(numeroConta);

        if (conta == null)
            throw new InvalidOperationException("Conta não encontrada");

        conta.Sacar(valor);

        _repository.Atualizar(conta);

        return conta;
    }

    public List<ContaBancaria> ListarContas()
    {
        return _repository.Listar();
    }

    public ContaBancaria CriarConta(int numeroConta, string titular, decimal saldoInicial)
    {
        var existente = _repository.ObterPorNumero(numeroConta);
        if (existente != null)
            throw new InvalidOperationException("Conta já existe");

        var conta = new ContaBancaria(numeroConta, titular, saldoInicial);

        _repository.Adicionar(conta);

        return conta;
    }


    public void RemoverConta(int numeroConta)
    {
        var conta = _repository.ObterPorNumero(numeroConta);

        if (conta == null)
            throw new InvalidOperationException("Conta não encontrada");

        _repository.Remover(numeroConta);
    }
}
