namespace AvtoSalon.DataAccess.Entities;

public class Car
{
    public long CarId { get; set; }
    public string CarName { get; set; }
    public long SalonId { get; set; }
    public AvtoSalonn AvtoSalon { get; set; }
}
