using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using CarBook.Application.Features.CQRS.Results.AboutResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers.Read;

public class GetAboutByIdQueryHandler
{
    private readonly IRepository<About> _repository;

    public GetAboutByIdQueryHandler(IRepository<About> repository)
    {
        _repository = repository;
    }

    public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
    {
        About data = await _repository.GetByIdAsync(query.Id);
        return new GetAboutByIdQueryResult
        {
            Id = data.Id,
            Title = data.Title,
            Description = data.Description,
            ImageUrl = data.ImageUrl
        };
    }
}