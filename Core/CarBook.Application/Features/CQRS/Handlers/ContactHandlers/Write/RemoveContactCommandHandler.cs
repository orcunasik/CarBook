using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers.Write;

public class RemoveContactCommandHandler
{
    private readonly IRepository<Contact> _repository;

    public RemoveContactCommandHandler(IRepository<Contact> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveContactCommand command)
    {
        Contact data = await _repository.GetByIdAsync(command.Id);
        await _repository.RemoveAsync(data);
    }
}