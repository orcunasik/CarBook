using CarBook.Application.Features.CQRS.Results.ContactResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers.Read;

public class GetContactQueryHandler
{
    private readonly IRepository<Contact> _repository;

    public GetContactQueryHandler(IRepository<Contact> repository)
    {
        _repository = repository;
    }

    public async Task<IList<GetContactQueryResult>> Handle()
    {
        IList<Contact> datas = await _repository.GetAllAsync();
        return datas.Select(c => new GetContactQueryResult
        {
            Id = c.Id,
            Name = c.Name,
            Email = c.Email,
            Subject = c.Subject,
            Message = c.Message,
            SendDate = c.SendDate
        }).ToList();
    }
}