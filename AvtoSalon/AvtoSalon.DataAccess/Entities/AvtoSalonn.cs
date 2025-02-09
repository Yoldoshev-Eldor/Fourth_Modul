namespace AvtoSalon.DataAccess.Entities;

public class AvtoSalonn
{
    public long SalonId {  get; set; }
    public string SalonName { get; set; }
    public DateTime RelasedDate { get; set; }
    public List<Car> Cars { get; set; }
}
