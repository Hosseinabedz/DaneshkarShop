using DaneshkarShop.Application.DTOs.SiteSide.Account;
using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Domain.Entities.User;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
    public  IActionResult Login()
    {
        return View();
    }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(UserLoginDTO userDTO)
    {
        if(ModelState.IsValid)
        {
            var user =  await _service.GetUserByMobile(userDTO.Mobile);
            if( user != null)
            {
                #region Setting cookie
                var claims = new List<Claim>
                {
                    new (ClaimTypes.NameIdentifier, user.UserId.ToString()),
                    new (ClaimTypes.MobilePhone, user.Mobile),
                    new (ClaimTypes.Name, user.UserName)
                };

                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(claimIdentity);

                var authProps = new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProps);
                #endregion
                return RedirectToAction("Index", "Home");
            }
        }
        return View();
    }
    #endregion

    #region Logout

    #endregion
}
