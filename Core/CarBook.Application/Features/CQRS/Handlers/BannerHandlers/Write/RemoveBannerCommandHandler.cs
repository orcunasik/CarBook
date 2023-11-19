using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers.Write;

public class RemoveBannerCommandHandler
{
    private readonly IRepository<Banner> _repository;

    public RemoveBannerCommandHandler(IRepository<Banner> bannerRepository)
    {
        _repository = bannerRepository;
    }

    public async Task Handle(RemoveBannerCommand command)
    {
        Banner data = await _repository.GetByIdAsync(command.Id);
        await _repository.RemoveAsync(data);
    }
}