using MediatorSample.Domain.Entities;

namespace MediatorSample.Domain.Interfaces;

public interface ICustomerRepository
{
    Task<Customer?> GetById(int id);

    Task<Customer?> GetByEmail(string email);

    Task<ICollection<Customer>> GetAll();

    Task Add(Customer customer);

    Task Update(Customer customer);

    Task Remove(Customer customer);
}