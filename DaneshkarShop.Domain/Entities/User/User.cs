using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaneshkarShop.Domain.Entities.User;

public class User
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Mobile { get; set; }
    public string Password { get; set; }
    public DateTime CreateDate { get; set; }
    public bool IsDelete { get; set; }
}
