using DaneshkarShop.Application.DTOs.AdminSide.User;
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

        #region Edit
        public async Task<IActionResult> Edit(int id)
        {
            var userEditDTO = await _userService.FillEditUserAdminSideDTO(id);
            return View(userEditDTO);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditUserAdminSideDTO userEditDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.EditUserAdminSide(userEditDTO);
                if(result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(userEditDTO);
        }

        #endregion

    }
}
