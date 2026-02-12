using Nova.Domain;

namespace Nova.Domain.Interfaces.Repositories;

public interface IContaBancariaRepository
{
    Task<ContaBancaria?> ObterPorNumero(int numeroConta);
    Task<List<ContaBancaria>> Listar();
    Task Adicionar(ContaBancaria conta);
    Task Atualizar(ContaBancaria conta);
    Task Remover(int numeroConta);
}
