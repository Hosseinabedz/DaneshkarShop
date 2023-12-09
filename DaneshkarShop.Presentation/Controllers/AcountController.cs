using DaneshkarShop.Application.DTOs.SiteSide.Account;
using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Domain.Entities.User;
using Microsoft.AspNetCore.Mvc;

namespace DaneshkarShop.Presentation.Controllers;

public class AccountController : Controller
{
    #region Ctor
    public AccountController(IUserService userService)
    {
        _service = userService;
    }

    public IUserService _service { get; }
    #endregion

    #region Register
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(UserRegisterDTO userDTO)
    {
        if(ModelState.IsValid)
        {
            bool result = await _service.RegisterUser(userDTO);
            if(result)
            {
                return RedirectToAction(nameof(Index), "Home"); 
            }
        }
        TempData["ErrorMessage"] = "کاربری با شماره موبایل وارد شده در سیستم وجود دارد!";
        return View();
    }
    #endregion

    #region Login

    #endregion

    #region Logout

    #endregion
}
