using AvtoSalon.DataAccess.Entities;
using AvtoSalon.Repository.Services;
using AvtoSalon.Service.Dtos;

namespace AvtoSalon.Service.Services;

public class CarService : ICarService
{
    private readonly ICarRepo _carRepo;

    public CarService(ICarRepo carRepo)
    {
        _carRepo = carRepo;
    }

    public async Task<long> AddCarAsync(CarCreateDto car)
    {
        var entiti = new Car()
        {
            CarName = car.CarName,
            SalonId = car.SalonId,
        };

        var result = await _carRepo.AddCarAsync(entiti);
        return result;

    }

    public async Task<List<CarGetDto>> GetAllCarsAsync()
    {
        var allEntiti = await _carRepo.GetAllCarsAsync();

        var result = new List<CarGetDto>();

        foreach (var s in allEntiti)
        {
            var res = new CarGetDto()
            {
                CarId = s.CarId,
                CarName = s.CarName,
                SalonId = s.SalonId,
                AvtoSalon = s.AvtoSalon,

            };
            result.Add(res);
        }

        return result;
    }

    public async Task<CarGetDto> GetCarByIdAsync(long carId)
    {
        var entiti =await _carRepo.GetCarByIdAsync(carId);

        var res = new CarGetDto()
        {
            CarId = entiti.CarId,
            CarName = entiti.CarName,
            SalonId = entiti.SalonId,
            AvtoSalon = entiti.AvtoSalon,

        };
        return res;
    }
}
