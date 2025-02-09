using AvtoSalon.DataAccess.Entities;

namespace AvtoSalon.Repository.Services;

public interface ICarRepo
{
    Task<long> AddCarAsync(Car car);

    Task<Car> GetCarByIdAsync(long carId);

    Task<List<Car>> GetAllCarsAsync();
}