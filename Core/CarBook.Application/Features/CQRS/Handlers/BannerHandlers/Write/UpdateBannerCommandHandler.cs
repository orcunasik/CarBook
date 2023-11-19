using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers.Write;

public class UpdateBannerCommandHandler
{
    private readonly IRepository<Banner> _repository;

    public UpdateBannerCommandHandler(IRepository<Banner> bannerRepository)
    {
        _repository = bannerRepository;
    }

    public async Task Handle(UpdateBannerCommand command)
    {
        Banner data = await _repository.GetByIdAsync(command.Id);
        data.Title = command.Title;
        data.Description = command.Description;
        data.VideoDescription = command.VideoDescription;
        data.VideoUrl = command.VideoUrl;
        await _repository.UpdateAsync(data);
    }
}