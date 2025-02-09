using AvtoSalon.DataAccess.Entities;
using AvtoSalon.Service.Dtos;

namespace AvtoSalon.Service.Services;

public interface ICarService
{


    Task<long> AddCarAsync(CarCreateDto car);

    Task<CarGetDto> GetCarByIdAsync(long carId);

    Task<List<CarGetDto>> GetAllCarsAsync();

}