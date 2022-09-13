using MediatorSample.Domain.Interfaces;
using MediatorSample.Infra.Context;
using MediatorSample.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediatorSample.CrossCutting.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
            )
        );

        services.AddScoped<ICustomerRepository, CustomerRepository>();

        return services;
    }
}