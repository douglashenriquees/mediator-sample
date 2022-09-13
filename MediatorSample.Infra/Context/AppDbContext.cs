using MediatorSample.Domain.Entities;
using MediatorSample.Infra.Configuration;
using Microsoft.EntityFrameworkCore;

namespace MediatorSample.Infra.Context;

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers => Set<Customer>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CustomerConfiguration());
    }
}