
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaneshkarShop.Application.DTOs.SiteSide.Account
{
    public class UserRegisterDTO
    {
        public string Username { get; set; }
        public string Mobile { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "کلمه عبور با تکرار آن متفاوت هستند")]
        public string RePassword { get; set; }
    }
}
