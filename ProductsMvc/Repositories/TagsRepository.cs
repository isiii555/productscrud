using Ardalis.GuardClauses;

using Mapster;

using ProductsMvc.Data;
using ProductsMvc.Repositories.Abstractions;
using ProductsMvc.Models.ViewModels;
using ProductsMvc.Models;

namespace ProductsMvc.Repositories;

public class TagsRepository : ITagsRepository
{
    private readonly AppDbContext _dbContext;


    public TagsRepository(AppDbContext dbContext)
    {
        _dbContext = Guard.Against.Null(dbContext);
    }

    public async Task AddTagAsync(TagViewModel tagViewModel)
    {
        await _dbContext.Tags.AddAsync(tagViewModel.Adapt<Tag>());

        await _dbContext.SaveChangesAsync();
    }
}