using Instagram.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Bll.Dtos;

public class AccountGetDto
{
    public long AccountId { get; set; }
    public string UserName { get; set; }
    public string Bio { get; set; }
    public List<Post> Posts { get; set; }

}
