using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers.Read;

public class GetCarByIdQueryHandler
{
    private readonly IRepository<Car> _repository;

    public GetCarByIdQueryHandler(IRepository<Car> repository)
    {
        _repository = repository;
    }

    public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
    {
        Car data = await _repository.GetByIdAsync(query.Id);
        return new GetCarByIdQueryResult
        {
            Id = data.Id,
            BrandId = data.BrandId,
            Model = data.Model,
            Seat = data.Seat,
            Kilometers = data.Kilometers,
            Luggage = data.Luggage,
            Fuel = data.Fuel,
            Transmission = data.Transmission,
            BigImageUrl = data.BigImageUrl,
            CoverImageUrl = data.CoverImageUrl
        };
    }
}