using DaneshkarShop.Application.Services.Implementation;
using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Application.Utilities;
using DaneshkarShop.Presentation.Areas.Admin.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DaneshkarShop.Presentation.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        #region Ctor
        public HomeController(IRoleService roleService, IUserService userService)
        {
            _roleService = roleService;
            _userService = userService;
        }

        public IRoleService _roleService { get; }
        public IUserService _userService { get; }
        #endregion
        public async Task<IActionResult> Index()
        {
            return View(await _userService.FillLandingPageModelDTO());
        }
        public IActionResult GetAllUsers()
        {
            return View();
        }
    }
}
