using MediatorSample.Domain.Entities;
using MediatorSample.Domain.Interfaces;
using MediatorSample.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace MediatorSample.Infra.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;

    public CustomerRepository(AppDbContext context)
    {
        _context = context ?? throw new ArgumentException(nameof(context));
    }

    public async Task<Customer?> GetById(int id)
    {
        return await _context.Customers.FindAsync(id);
    }

    public async Task<Customer?> GetByEmail(string email)
    {
        return await _context.Customers.FirstOrDefaultAsync(x => x.Email.Equals(email));
    }

    public async Task<ICollection<Customer>> GetAll()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task Add(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Customer customer)
    {
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
    }

    public async Task Remove(Customer customer)
    {
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}