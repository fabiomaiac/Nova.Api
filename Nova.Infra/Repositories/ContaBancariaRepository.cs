using Microsoft.EntityFrameworkCore;
using Nova.Domain;
using Nova.Domain.Interfaces.Repositories;
using Nova.Infra.Data;

namespace Nova.Infra.Repositories;

public class ContaBancariaRepository : IContaBancariaRepository
{
    private readonly AppDbContext _context;

    public ContaBancariaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ContaBancaria?> ObterPorNumero(int numeroConta)
    {
        return await _context.Contas
            .FirstOrDefaultAsync(c => c.NumeroConta == numeroConta);
    }

    public async Task<List<ContaBancaria>> Listar()
    {
        return await _context.Contas
            .ToListAsync();
    }

    public async Task Adicionar(ContaBancaria conta)
    {
        _context.Contas.Add(conta);
        await _context.SaveChangesAsync();
    }

    public async Task Atualizar(ContaBancaria conta)
    {
        _context.Contas.Update(conta);
        await _context.SaveChangesAsync();
    }

    public async Task Remover(int numeroConta)
    {
        var conta = await ObterPorNumero(numeroConta);

        if (conta == null)
            return;

        _context.Contas.Remove(conta);
        await _context.SaveChangesAsync();
    }
}
