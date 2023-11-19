using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers.Read;

public class GetCarQueryHandler
{
    private readonly IRepository<Car> _repository;

    public GetCarQueryHandler(IRepository<Car> repository)
    {
        _repository = repository;
    }

    public async Task<IList<GetCarQueryResult>> Handle()
    {
        IList<Car> datas = await _repository.GetAllAsync();
        return datas.Select(c => new GetCarQueryResult
        {
            Id = c.Id,
            BrandId = c.BrandId,
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