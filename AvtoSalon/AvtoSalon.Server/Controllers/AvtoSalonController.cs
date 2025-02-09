using AvtoSalon.Service.Dtos;
using AvtoSalon.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace AvtoSalon.Server.Controllers
{
    [Route("api/AvtoSalon")]
    [ApiController]
    public class AvtoSalonController : ControllerBase
    {
        private readonly IAvtoSalonService _service;

        public AvtoSalonController(IAvtoSalonService service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public async Task<long> AddSalon(AvtoSalonCreateDto salon)
        {
            return await _service.AddSalonAsync(salon);
        }

        [HttpGet("getAll")]

        public async Task<List<AvtoSalonGetDto>> GetAll()
        {
            return await _service.GetAllSalonsAsync();
        }

        [HttpGet("getById")]

        public async Task<AvtoSalonGetDto> GetById(long id)
        {
            return await _service.GetSalonByIdAsync(id);
        }
    }
}
