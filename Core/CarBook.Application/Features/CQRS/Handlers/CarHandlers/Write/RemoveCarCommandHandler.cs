using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers.Write;

public class RemoveCarCommandHandler
{
    private readonly IRepository<Car> _repository;

    public RemoveCarCommandHandler(IRepository<Car> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveCarCommand command)
    {
        Car data = await _repository.GetByIdAsync(command.Id);
        await _repository.RemoveAsync(data);
    }
}