using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterface;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers.Read;

public class GetCarWithBrandQueryHandler
{
    private readonly ICarRepository _repository;

    public GetCarWithBrandQueryHandler(ICarRepository carRepository)
    {
        _repository = carRepository;
    }

    public async Task<IList<GetCarWithBrandQueryResult>> Handle()
    {
        IList<Car> datas = await _repository.GetCarsListWithBrandAsync();
        return datas.Select(c => new GetCarWithBrandQueryResult
        {
            Id = c.Id,
            BrandId = c.BrandId,
            BrandName = c.Brand.Name,
            Model = c.Model,
            Seat = c.Seat,
            Kilometers = c.Kilometers,
            Luggage = c.Luggage,
            Fuel = c.Fuel,
            Transmission = c.Transmission,
            BigImageUrl = c.BigImageUrl,
            CoverImageUrl = c.CoverImageUrl
        }).ToList();
    }
}