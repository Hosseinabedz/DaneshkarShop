using DaneshkarShop.Application.DTOs.AdminSide.User;
using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Presentation.HttpManager;
using Microsoft.AspNetCore.Mvc;

namespace DaneshkarShop.Presentation.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        #region Ctor
        public UserController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        public IUserService _userService { get; }
        public IRoleService _roleService { get; }
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
            if (userEditDTO == null) return NotFound();

            #region View Data
            ViewData["Roles"] = await _roleService.GetListOfRoles();
            #endregion




            return View(userEditDTO);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditUserAdminSideDTO userEditDTO, List<int> SelectedRoles)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.EditUserAdminSide(userEditDTO, SelectedRoles);
                if(result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(userEditDTO);
        }

        #endregion

        #region Detail
        public async Task<IActionResult> Detail(int id)
        {
            var userDetailDTO = await _userService.FillEditUserAdminSideDTO(id);
            if (userDetailDTO == null) return NotFound();

            #region View Data
            ViewData["Roles"] = await _roleService.GetListOfRoles();
            #endregion
            return View(userDetailDTO);
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int id, CancellationToken cancellation)
        {
            var res = await _userService.DeleteUser(id, cancellation);
            if (res)
            {
                return ApiResponse.SetResponse(ApiResponseStatus.Success, null, "عملیات باموفقیت انجام شده است.");
            }
            return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, "عملیات باشکست مواجه شده است.");
        }
        #endregion
            
    } 
}
