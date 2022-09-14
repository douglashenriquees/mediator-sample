using MediatorSample.Domain.Entities;
using MediatorSample.Infra.Configuration;
using Microsoft.EntityFrameworkCore;

namespace MediatorSample.Infra.Context;

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers => Set<Customer>();

    public AppDbContext()
    {
        // apenas para executar o migrations
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // apenas para executar o migrations

        optionsBuilder.UseSqlServer();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CustomerConfiguration());
    }
}