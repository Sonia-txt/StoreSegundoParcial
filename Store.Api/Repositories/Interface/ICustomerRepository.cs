namespace Store.Api.Repositories.Interface;
using Store.Core.Entities;
public interface ICustomerRepository
{
    //metodo para guardar las custemer
    Task<Customer> SaveAsync(Customer customer);
    //metodo para actualizar las custemer
    Task<Customer> UpdateAsync(Customer customer);
    //metodo para retornat una lidta de categorias de producto
    Task<List<Customer>> GetAllAsync();
    //metodo para retornar el id de las categorias del producto que se borrara
    Task<bool> DeleteAsync(int id);
    //metodo para obtener una categoria por id
    Task<Customer> GetById(int id);
}