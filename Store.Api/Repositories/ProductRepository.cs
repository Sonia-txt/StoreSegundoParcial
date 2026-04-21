using Store.Core.Entities;
using Store.Api.Repositories.Interface;

namespace Store.Api.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly List<Product> _products = new();
    private int _nextId = 1;

    public async Task<List<Product>> GetAllAsync() => await Task.FromResult(_products.ToList());

    public async Task<Product> GetById(int id) => 
        await Task.FromResult(_products.FirstOrDefault(x => x.Id == id));

    public async Task<Product> SaveAsync(Product product)
    {
        product.Id = _nextId++;
        _products.Add(product);
        return await Task.FromResult(product);
    }

    public async Task<bool> UpdateAsync(Product product)
    {
        var index = _products.FindIndex(x => x.Id == product.Id);
        if (index == -1) return await Task.FromResult(false);
        _products[index] = product;
        return await Task.FromResult(true);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = _products.FirstOrDefault(x => x.Id == id);
        if (product == null) return await Task.FromResult(false);
        return await Task.FromResult(_products.Remove(product));
    }
}