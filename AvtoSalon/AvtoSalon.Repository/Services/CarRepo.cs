using AvtoSalon.DataAccess;
using AvtoSalon.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtoSalon.Repository.Services;

public class CarRepo : ICarRepo
{
    private readonly MainContext _mainContext;

    public CarRepo(MainContext mainContext)
    {
        _mainContext = mainContext;
    }

    public async Task<long> AddCarAsync(Car car)
    {
        await _mainContext.Cars.AddAsync(car);
        await _mainContext.SaveChangesAsync();

        return car.CarId;
    }

    public async Task<List<Car>> GetAllCarsAsync()
    {
        return  _mainContext.Cars.ToList();
    }

    public async Task<Car> GetCarByIdAsync(long carId)
    {
        var all = _mainContext.Cars.ToList();
        var res = all.FirstOrDefault(c => c.CarId == carId);
        if (res == null)
        {
            throw new Exception("Null");
        }
        return res;

    }
}
