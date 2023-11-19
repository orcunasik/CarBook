using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers.Write;

public class UpdateCarCommandHandler
{
    private readonly IRepository<Car> _repository;

    public UpdateCarCommandHandler(IRepository<Car> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateCarCommand command)
    {
        Car data = await _repository.GetByIdAsync(command.Id);
        data.BrandId = command.BrandId;
        data.Model = command.Model;
        data.Seat = command.Seat;
        data.Kilometers = command.Kilometers;
        data.Fuel = command.Fuel;
        data.Transmission = command.Transmission;
        data.Luggage = command.Luggage;
        data.CoverImageUrl = command.CoverImageUrl;
        data.BigImageUrl = command.BigImageUrl;
        await _repository.UpdateAsync(data);
    }
}