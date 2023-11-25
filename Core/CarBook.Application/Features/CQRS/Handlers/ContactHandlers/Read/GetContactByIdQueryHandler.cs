using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using CarBook.Application.Features.CQRS.Results.ContactResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers.Read;

public class GetContactByIdQueryHandler
{
    private readonly IRepository<Contact> _repository;

    public GetContactByIdQueryHandler(IRepository<Contact> repository)
    {
        _repository = repository;
    }

    public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
    {
        Contact data = await _repository.GetByIdAsync(query.Id);
        return new GetContactByIdQueryResult
        {
            Id = data.Id,
            Email = data.Email,
            Message = data.Message,
            Name = data.Name,
            Subject = data.Subject,
            SendDate = data.SendDate
        };
    }
}