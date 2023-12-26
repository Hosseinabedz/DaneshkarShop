using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaneshkarShop.Application.DTOs.AdminSide.User
{
    public class EditUserAdminSideDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Mobile { get; set; }   
        //public bool SuperAdmin { get; set; }
        //public List<int> UserSelectedRoleId { get; set; }
        public FileStream? Avatar { get; set; } 
        public string? OriginalAvatar { get; set; }
    }
}
