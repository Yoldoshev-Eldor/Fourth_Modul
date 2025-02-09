using AvtoSalon.DataAccess.Entities;

namespace AvtoSalon.Service.Dtos;

public class AvtoSalonGetDto
{
    public long SalonId { get; set; }
    public string SalonName { get; set; }
    public DateTime RelasedDate { get; set; }
    public List<Car> Cars { get; set; }

}
