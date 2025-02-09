using AvtoSalon.DataAccess.Entities;

namespace AvtoSalon.Service.Dtos;

public class CarCreateDto
{
    public string CarName { get; set; }
    public long SalonId { get; set; }

}
