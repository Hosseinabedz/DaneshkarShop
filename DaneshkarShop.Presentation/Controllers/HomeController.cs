using DaneshkarShop.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DaneshkarShop.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}