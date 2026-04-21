using Store.Core.Entities;
using Store.Api.Repositories.Interface;

namespace Store.Api.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly List<Customer> _customers = new();
    private int _nextId = 1;

    public async Task<List<Customer>> GetAllAsync() => await Task.FromResult(_customers.ToList());

    public async Task<Customer> GetById(int id) => 
        await Task.FromResult(_customers.FirstOrDefault(x => x.Id == id));

    public async Task<Customer> SaveAsync(Customer customer)
    {
        customer.Id = _nextId++;
        _customers.Add(customer);
        return await Task.FromResult(customer);
    }

    public async Task<bool> UpdateAsync(Customer customer)
    {
        var index = _customers.FindIndex(x => x.Id == customer.Id);
        if (index == -1) return await Task.FromResult(false);
        _customers[index] = customer;
        return await Task.FromResult(true);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var customer = _customers.FirstOrDefault(x => x.Id == id);
        if (customer == null) return await Task.FromResult(false);
        return await Task.FromResult(_customers.Remove(customer));
    }
}