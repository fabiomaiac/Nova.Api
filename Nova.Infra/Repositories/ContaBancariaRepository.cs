using Microsoft.EntityFrameworkCore;
using Nova.Domain;
using Nova.Domain.Repositories;
using Nova.Infra.Data;

namespace Nova.Infra.Repositories;

public class ContaBancariaRepository : IContaBancariaRepository
{
    private readonly AppDbContext _context;

    public ContaBancariaRepository(AppDbContext context)
    {
        _context = context;
    }

    public ContaBancaria? ObterPorNumero(int numeroConta)
    {
        return _context.Contas
            .FirstOrDefault(c => c.NumeroConta == numeroConta);
    }

    public List<ContaBancaria> Listar()
    {
        return _context.Contas.ToList();
    }

    public void Adicionar(ContaBancaria conta)
    {
        _context.Contas.Add(conta);
        _context.SaveChanges();
    }

    public void Atualizar(ContaBancaria conta)
    {
        _context.SaveChanges();
    }

    public void Remover(int numeroConta)
    {
        var conta = ObterPorNumero(numeroConta);

        if (conta == null)
            return;

        _context.Contas.Remove(conta);
        _context.SaveChanges();
    }
}
