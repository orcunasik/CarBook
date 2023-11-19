using CarBook.Application.Features.CQRS.Results.BannerResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers.Read;

public class GetBannerQueryHandler
{
    private readonly IRepository<Banner> _repository;

    public GetBannerQueryHandler(IRepository<Banner> bannerRepository)
    {
        _repository = bannerRepository;
    }

    public async Task<IList<GetBannerQueryResult>> Handle()
    {
        IList<Banner> datas = await _repository.GetAllAsync();
        return datas.Select(b => new GetBannerQueryResult
        {
            Description = b.Description,
            Id = b.Id,
            Title = b.Title,
            VideoDescription = b.VideoDescription,
            VideoUrl = b.VideoUrl
        }).ToList();
    }
}