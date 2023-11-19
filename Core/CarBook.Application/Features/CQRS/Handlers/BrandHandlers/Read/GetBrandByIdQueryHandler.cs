using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using CarBook.Application.Features.CQRS.Results.BrandResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers.Read;

public class GetBrandByIdQueryHandler
{
    private readonly IRepository<Brand> _repository;

    public GetBrandByIdQueryHandler(IRepository<Brand> repository)
    {
        _repository = repository;
    }

    public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery query)
    {
        Brand data = await _repository.GetByIdAsync(query.Id);
        return new GetBrandByIdQueryResult
        {
            Id = data.Id,
            Name = data.Name
        };
    }
}