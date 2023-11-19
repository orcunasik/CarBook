using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Results.BrandResults;

public class GetBrandQueryResult
{
    public int Id { get; set; }
    public string Name { get; set; }
}