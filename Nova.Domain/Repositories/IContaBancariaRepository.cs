using Nova.Domain;

namespace Nova.Domain.Repositories;

public interface IContaBancariaRepository
{
    ContaBancaria? ObterPorNumero(int numeroConta);
    List<ContaBancaria> Listar();
    void Adicionar(ContaBancaria conta);
    void Atualizar(ContaBancaria conta);
    void Remover(int numeroConta);
}
