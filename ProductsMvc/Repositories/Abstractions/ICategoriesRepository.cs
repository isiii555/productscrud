using ProductsMvc.Models.ViewModels;


namespace ProductsMvc.Repositories.Abstractions;

public interface ICategoriesRepository
{
    Task AddCategoryAsync(CategoryViewModel categoryViewModel);
}