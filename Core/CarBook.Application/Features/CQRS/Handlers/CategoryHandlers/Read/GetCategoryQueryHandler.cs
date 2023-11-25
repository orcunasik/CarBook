using CarBook.Application.Features.CQRS.Results.CategoryResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandlers.Read;

public class GetCategoryQueryHandler
{
    private readonly IRepository<Category> _repository;

    public GetCategoryQueryHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task<IList<GetCategoryQueryResult>> Handle()
    {
        IList<Category> datas = await _repository.GetAllAsync();
        return datas.Select(c => new GetCategoryQueryResult
        {
            Id = c.Id,
            Name = c.Name
        }).ToList();
    }
}