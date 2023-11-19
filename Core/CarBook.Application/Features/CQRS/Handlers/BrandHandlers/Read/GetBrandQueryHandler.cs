using CarBook.Application.Features.CQRS.Results.BrandResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers.Read;

public class GetBrandQueryHandler
{
    private readonly IRepository<Brand> _repository;

    public GetBrandQueryHandler(IRepository<Brand> repository)
    {
        _repository = repository;
    }

    public async Task<IList<GetBrandQueryResult>> Handle()
    {
        IList<Brand> datas = await _repository.GetAllAsync();
        return datas.Select(b => new GetBrandQueryResult
        {
            Id = b.Id,
            Name = b.Name
        }).ToList();
    }
}