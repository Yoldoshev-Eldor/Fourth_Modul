using AvtoSalon.DataAccess.Entities;
using AvtoSalon.Repository.Services;
using AvtoSalon.Service.Dtos;

namespace AvtoSalon.Service.Services;

public class AvtoSalonService : IAvtoSalonService
{
    private readonly IAvtoSalonRepo _repo;

    public AvtoSalonService(IAvtoSalonRepo repo)
    {
        _repo = repo;
    }

    public async Task<long> AddSalonAsync(AvtoSalonCreateDto avtoSalon)
    {
        var res = new AvtoSalonn()
        {
            SalonName = avtoSalon.SalonName,
            RelasedDate = DateTime.Now,
        };
        var result = await _repo.AddSalonAsync(res);
        return result;
    }

    public async Task<List<AvtoSalonGetDto>> GetAllSalonsAsync()
    {
       var allEntiti =await _repo.GetAllSalonsAsync();

        var result = new List<AvtoSalonGetDto>();
        
        foreach (var s in allEntiti)
        {
            var res = new AvtoSalonGetDto()
            {
                SalonId = s.SalonId,
                SalonName = s.SalonName,
                RelasedDate = s.RelasedDate,
                Cars = s.Cars,

            };
            result.Add(res);
        }

        return result;
    }

    public async Task<AvtoSalonGetDto> GetSalonByIdAsync(long salonId)
    {
        var s = await _repo.GetSalonByIdAsync(salonId);

        var dto = new AvtoSalonGetDto()
        {
            SalonId = s.SalonId,
            SalonName = s.SalonName,
            RelasedDate = s.RelasedDate,
            Cars = s.Cars,

        };
        return dto;
    }
}
