using Microsoft.EntityFrameworkCore;
using Nova.Domain;

namespace Nova.Infra.Data;

public class AppDbContext : DbContext
{
    public DbSet<ContaBancaria> Contas => Set<ContaBancaria>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContaBancaria>()
            .HasKey(c => c.NumeroConta);

        base.OnModelCreating(modelBuilder);
    }
}
