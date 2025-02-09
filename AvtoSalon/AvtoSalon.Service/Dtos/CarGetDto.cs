using AvtoSalon.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtoSalon.Service.Dtos;

public class CarGetDto
{

    public long CarId { get; set; }
    public string CarName { get; set; }
    public long SalonId { get; set; }
    public AvtoSalonn AvtoSalon { get;  set;}

}
