using AvtoSalon.DataAccess.Entities;
using AvtoSalon.Service.Dtos;

namespace AvtoSalon.Service.Services;

public interface IAvtoSalonService
{
    Task<long> AddSalonAsync(AvtoSalonCreateDto avtoSalon);

    Task<AvtoSalonGetDto> GetSalonByIdAsync(long salonId);

    Task<List<AvtoSalonGetDto>> GetAllSalonsAsync();

}