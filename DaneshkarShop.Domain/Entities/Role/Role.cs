using DaneshkarShop.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaneshkarShop.Domain.Entities.Role
{
    public class Role
    {
         //Properties
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string RoleTitle { get; set; }
        [MaxLength(100)]
        [Required]
        public string RoleUniqueName { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }


        //Relations
        public User.User User { get; set; }
        public ICollection<UserSelectedRole> UserSelectedRoles { get; set; }
    }
}
