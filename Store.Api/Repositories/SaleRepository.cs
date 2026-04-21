using Store.Core.Entities;
using Store.Api.Repositories.Interface;

namespace Store.Api.Repositories;

public class SaleRepository : ISaleRepository
{
    private readonly List<Sale> _sales = new();
    private int _nextId = 1;

    public async Task<List<Sale>> GetAllAsync() => await Task.FromResult(_sales.ToList());

    public async Task<Sale> GetById(int id) => 
        await Task.FromResult(_sales.FirstOrDefault(x => x.Id == id));

    public async Task<Sale> SaveAsync(Sale sale)
    {
        sale.Id = _nextId++;
        _sales.Add(sale);
        return await Task.FromResult(sale);
    }

    public async Task<bool> UpdateAsync(Sale sale)
    {
        var index = _sales.FindIndex(x => x.Id == sale.Id);
        if (index == -1) return await Task.FromResult(false);
        _sales[index] = sale;
        return await Task.FromResult(true);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var sale = _sales.FirstOrDefault(x => x.Id == id);
        if (sale == null) return await Task.FromResult(false);
        return await Task.FromResult(_sales.Remove(sale));
    }
}