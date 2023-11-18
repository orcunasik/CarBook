using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers.Write;

public class UpdateAboutCommandHandler
{
    private readonly IRepository<About> _repository;

    public UpdateAboutCommandHandler(IRepository<About> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateAboutCommand command)
    {
        About data = await _repository.GetByIdAsync(command.Id);
        data.Title = command.Title;
        data.Description = command.Description;
        data.ImageUrl = command.ImageUrl;
        await _repository.UpdateAsync(data);
    }
}