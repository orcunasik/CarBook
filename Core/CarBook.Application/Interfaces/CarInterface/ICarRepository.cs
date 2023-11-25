using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.CarInterface;

public interface ICarRepository
{
    Task<IList<Car>> GetCarsListWithBrandAsync();
}