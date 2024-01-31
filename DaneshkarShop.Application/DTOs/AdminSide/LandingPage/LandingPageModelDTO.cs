using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaneshkarShop.Application.DTOs.AdminSide.LandingPage
{
    public record LandingPageModelDTO
    {
        public int CountOfActiveUsers { get; set; }
    }
}
