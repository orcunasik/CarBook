namespace CarBook.Application.Features.CQRS.Queries.ContactQueries;

public class GetContactByIdQuery
{
    public int Id { get; set; }

    public GetContactByIdQuery(int id)
    {
        Id = id;
    }
}