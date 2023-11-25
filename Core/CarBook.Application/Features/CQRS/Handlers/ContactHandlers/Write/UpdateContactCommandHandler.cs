using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers.Write;

public class UpdateContactCommandHandler
{
    private readonly IRepository<Contact> _repository;

    public UpdateContactCommandHandler(IRepository<Contact> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateContactCommand command)
    {
        Contact data = await _repository.GetByIdAsync(command.Id);
        data.Name = command.Name;
        data.Email = command.Email;
        data.Subject = command.Subject;
        data.Message = command.Message;
        data.SendDate = command.SendDate;
        await _repository.UpdateAsync(data);
    }
}