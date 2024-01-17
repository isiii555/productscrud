using ProductsMvc.Models.ViewModels;


namespace ProductsMvc.Repositories.Abstractions;

public interface ITagsRepository
{
    Task AddTagAsync(TagViewModel tagViewModel);
}