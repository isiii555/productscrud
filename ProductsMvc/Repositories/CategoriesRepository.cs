using Ardalis.GuardClauses;

using Mapster;

using ProductsMvc.Data;
using ProductsMvc.Data.Entities;
using ProductsMvc.Repositories.Abstractions;
using ProductsMvc.Models.ViewModels;
using ProductsMvc.Models;

namespace ProductsMvc.Repositories;

public class CategoriesRepository : ICategoriesRepository
{
    private readonly AppDbContext _dbContext;


    public CategoriesRepository(AppDbContext dbContext)
    {
        _dbContext = Guard.Against.Null(dbContext);
    }


    public async Task AddCategoryAsync(CategoryViewModel categoryViewModel)
    {
        await _dbContext.Categories.AddAsync(categoryViewModel.Adapt<Category>());

        await _dbContext.SaveChangesAsync();
    }
}