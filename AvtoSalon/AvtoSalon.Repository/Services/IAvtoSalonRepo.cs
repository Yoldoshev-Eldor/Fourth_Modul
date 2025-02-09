using AvtoSalon.DataAccess.Entities;

namespace AvtoSalon.Repository.Services;

public interface IAvtoSalonRepo
{

    Task<long> AddSalonAsync(AvtoSalonn avtoSalon);

    Task<AvtoSalonn> GetSalonByIdAsync(long salonId);

    Task<List<AvtoSalonn>> GetAllSalonsAsync();


}