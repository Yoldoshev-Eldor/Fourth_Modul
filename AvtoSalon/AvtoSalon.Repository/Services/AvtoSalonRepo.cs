using AvtoSalon.DataAccess;
using AvtoSalon.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtoSalon.Repository.Services;

public class AvtoSalonRepo : IAvtoSalonRepo
{
    private readonly MainContext _mainContext;

    public AvtoSalonRepo(MainContext mainContext)
    {
        _mainContext = mainContext;
    }

    public async Task<long> AddSalonAsync(AvtoSalonn avtoSalon)
    {
        await _mainContext.AvtoSalons.AddAsync(avtoSalon);

        await _mainContext.SaveChangesAsync();

        return avtoSalon.SalonId;
    }

    public async Task<List<AvtoSalonn>> GetAllSalonsAsync()
    {
        var all = _mainContext.AvtoSalons.ToList();
        return all;
    }

    public async Task<AvtoSalonn> GetSalonByIdAsync(long salonId)
    {
        var all = _mainContext.AvtoSalons.ToList();
        var res = all.FirstOrDefault(c => c.SalonId == salonId);
        if(res == null)
        {
            throw new Exception("Null");
        }
        return res;
    }
}
