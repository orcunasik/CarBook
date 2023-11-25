using CarBook.Application.Interfaces.CarInterface;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.CarRepository;

public class CarRepository : ICarRepository
{
    private readonly CarBookContext _context;

    public CarRepository(CarBookContext context)
    {
        _context = context;
    }

    public async Task<IList<Car>> GetCarsListWithBrandAsync()
    {
        List<Car> datas = await _context.Cars.Include(c => c.Brand).ToListAsync();
        return datas;
    }
}