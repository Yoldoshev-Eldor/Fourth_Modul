using AvtoSalon.Service.Dtos;
using AvtoSalon.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AvtoSalon.Server.Controllers
{
    [Route("api/Car")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _service;

        public CarController(ICarService service)
        {
            _service = service;
        }
        [HttpPost("addCar")]

        public async Task<long> AddCar(CarCreateDto car)
        {
            return await _service.AddCarAsync(car);
        }

        [HttpGet("getAll")]

        public async Task<List<CarGetDto>> GetAll()
        {
            return await _service.GetAllCarsAsync();
        }


    }
}
