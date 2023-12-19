using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Application.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DaneshkarShop.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        #region Ctor
        public HomeController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public IRoleService _roleService { get; }
        #endregion
        public async Task<IActionResult> Index()
        {
            int userId = (int)User.GetUserId();
            var userRoles = await _roleService.GetUserRolesByUserId(userId);
            bool permision = false;
            foreach (var role in userRoles)
            {
                if (role.RoleUniqueName == "Admin" ) permision = true;
            }
            if(!permision)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
