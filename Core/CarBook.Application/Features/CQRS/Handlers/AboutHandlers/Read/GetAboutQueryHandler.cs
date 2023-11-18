using CarBook.Application.Features.CQRS.Results.AboutResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers.Read;

public class GetAboutQueryHandler
{
    private readonly IRepository<About> _repository;

    public GetAboutQueryHandler(IRepository<About> repository)
    {
        _repository = repository;
    }

    public async Task<IList<GetAboutQueryResult>> Handle()
    {
        IList<About> datas = await _repository.GetAllAsync();
        return datas.Select(a => new GetAboutQueryResult
        {
            Id = a.Id,
            Title = a.Title,
            Description = a.Description,
            ImageUrl = a.ImageUrl
        }).ToList();
    }
}