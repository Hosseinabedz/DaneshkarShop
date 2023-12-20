using DaneshkarShop.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DaneshkarShop.Presentation.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        #region Ctor
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IUserService _userService { get; }
        #endregion

        #region List Of Users
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsresAsync();
            if (users == null) return NotFound();
            return View(users);
        }
        #endregion

    }
}
