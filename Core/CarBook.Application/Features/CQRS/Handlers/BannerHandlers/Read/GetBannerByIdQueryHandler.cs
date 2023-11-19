using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using CarBook.Application.Features.CQRS.Results.BannerResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers.Read;

public class GetBannerByIdQueryHandler
{
    private readonly IRepository<Banner> _repository;

    public GetBannerByIdQueryHandler(IRepository<Banner> bannerRepository)
    {
        _repository = bannerRepository;
    }

    public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
    {
        Banner data = await _repository.GetByIdAsync(query.Id);
        return new GetBannerByIdQueryResult
        {
            Id = data.Id,
            Title = data.Title,
            Description = data.Description,
            VideoDescription = data.Description,
            VideoUrl = data.VideoUrl
        };
    }
}