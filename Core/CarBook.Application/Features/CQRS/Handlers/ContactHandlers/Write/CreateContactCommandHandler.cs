using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers.Write;

public class CreateContactCommandHandler
{
    private readonly IRepository<Contact> _repository;

    public CreateContactCommandHandler(IRepository<Contact> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateContactCommand command)
    {
        await _repository.CreateAsync(new Contact
        {
            Name = command.Name,
            Email = command.Email,
            Subject = command.Subject,
            Message = command.Message,
            SendDate = command.SendDate
        });
    }
}