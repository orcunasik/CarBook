using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers.Write;

public class RemoveAboutCommandHandler
{
    private readonly IRepository<About> _repository;

    public RemoveAboutCommandHandler(IRepository<About> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveAboutCommand command)
    {
        About data = await _repository.GetByIdAsync(command.Id);
        await _repository.RemoveAsync(data);
    }
}