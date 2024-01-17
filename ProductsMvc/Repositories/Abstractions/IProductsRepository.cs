using ProductsMvc.Models;
using ProductsMvc.Models.ViewModels;


namespace ProductsMvc.Repositories.Abstractions;

public interface IProductsRepository
{
    Task<List<Product>> GetProductsAsync();

    Task<List<Tag>> GetAllTagsAsync();

    Task<List<Category>> GetAllCategoriesAsync();

    Task<Product> GetProductAsync(int id);

    Task AddProductAsync(ProductViewModel productViewModel);

    Task RemoveProductAsync(int id);

    Task UpdateProductAsync(int id,ProductViewModel productViewModel);
}