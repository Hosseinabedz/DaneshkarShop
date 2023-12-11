using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaneshkarShop.Domain.Entities.User;
namespace DaneshkarShop.Domain.Entities.Role;

public class UserSelectedRole
{
    ///Properties
    public int Id { get; set; }
    public int RoleId { get; set; }
    public int UserId { get; set; }

    //Relations
    public Role Role { get; set; }
    public User.User User { get; set; }


}
