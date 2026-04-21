using Store.Core.Entities;
using Store.Api.Repositories.Interface;

namespace Store.Api.Repositories;

public class SaleDetailRepository : ISaleDetailRepository
{
    private readonly List<SaleDetail> _details = new();
    private int _nextId = 1;

    public async Task<List<SaleDetail>> GetAllAsync() => await Task.FromResult(_details.ToList());

    public async Task<SaleDetail> GetById(int id) => 
        await Task.FromResult(_details.FirstOrDefault(x => x.Id == id));

    public async Task<SaleDetail> SaveAsync(SaleDetail detail)
    {
        detail.Id = _nextId++;
        _details.Add(detail);
        return await Task.FromResult(detail);
    }

    public async Task<bool> UpdateAsync(SaleDetail detail)
    {
        var index = _details.FindIndex(x => x.Id == detail.Id);
        if (index == -1) return await Task.FromResult(false);
        _details[index] = detail;
        return await Task.FromResult(true);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var detail = _details.FirstOrDefault(x => x.Id == id);
        if (detail == null) return await Task.FromResult(false);
        return await Task.FromResult(_details.Remove(detail));
    }
}