using MediatorSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediatorSample.Infra.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(100);
        builder.Property(x => x.Email).HasMaxLength(150);

        builder.HasData(
            new Customer() { Id = 1, Name = "Jim Morrison", Email = "jim@email.com" },
            new Customer() { Id = 2, Name = "Elvis Presley", Email = "elvis@email.com" },
            new Customer() { Id = 3, Name = "Janis Joplin", Email = "janis@email.com" }
        );
    }
}