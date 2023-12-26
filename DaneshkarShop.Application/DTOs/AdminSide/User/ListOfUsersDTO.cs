using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaneshkarShop.Application.DTOs.AdminSide.User
{
    public class ListOfUsersDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Mobile { get; set; }
        public DateTime CreateDate { get; set; }
        public string? Avatar { get; set; }
    }
}
