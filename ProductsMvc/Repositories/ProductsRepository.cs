using System.Collections.Concurrent;

using Ardalis.GuardClauses;

using Mapster;

using Microsoft.EntityFrameworkCore;

using ProductsMvc.Data;
using ProductsMvc.Repositories.Abstractions;
using ProductsMvc.Models.ViewModels;
using ProductsMvc.Models;
using ProductsMvc.Helpers;

namespace ProductsMvc.Repositories;

public class ProductsRepository : IProductsRepository
{
    private readonly AppDbContext _dbContext;


    public ProductsRepository(AppDbContext dbContext)
    {
        _dbContext = Guard.Against.Null(dbContext);
    }


    public async Task<List<Product>> GetProductsAsync()
    {
        return await _dbContext.Products
            .Include(p => p.Category)
            .Include(p => p.Tags)
            .ToListAsync();
    }

    public async Task<List<Tag>> GetAllTagsAsync()
    {
        return await _dbContext.Tags.ToListAsync();
    }

    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        return await _dbContext.Categories.ToListAsync();
    }

    public async Task AddProductAsync(ProductViewModel productViewModel)
    {
        var resultProduct = productViewModel.Adapt<Product>();
        resultProduct.Tags = _dbContext.Tags.Where(t => productViewModel!.TagIds!.Contains(t.Id)).ToList();
        resultProduct.ImagePath = await UploadFileHelper.UploadFile(productViewModel.Image);

        await _dbContext.Products.AddAsync(resultProduct);

        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveProductAsync(int id)
    {
        _dbContext.Remove(_dbContext.Products.Where(p => p.Id == id).FirstOrDefault());

        await _dbContext.SaveChangesAsync();
    }

    public Task<Product> GetProductAsync(int id)
    {
        return _dbContext.Products
            .Include(p => p.Tags)
            .Include(p => p.Category)
            .Where(t => t.Id == id)
            .FirstOrDefaultAsync()!;
    }

    public async Task UpdateProductAsync(int id, ProductViewModel productViewModel)
    {
        var product = await _dbContext.Products.Include(p => p.Tags).FirstOrDefaultAsync(p => p.Id == id);
        product!.Description = productViewModel.Description;
        product.Name = productViewModel.Name;
        product.CategoryId = productViewModel.CategoryId;
        product.Price = productViewModel.Price;
        if (productViewModel.TagIds is not null) {
            product!.Tags = await _dbContext.Tags.Where(t => productViewModel.TagIds.Contains(t.Id)).ToListAsync();
        }
        if (productViewModel.Image is not null)
        {
            product!.ImagePath = await UploadFileHelper.UploadFile(productViewModel.Image);
        }
        _dbContext.Update(product);
        await _dbContext.SaveChangesAsync();
    }
}