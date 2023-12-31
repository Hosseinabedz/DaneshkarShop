﻿using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Application.Utilities;
using DaneshkarShop.Presentation.Areas.Admin.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DaneshkarShop.Presentation.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        #region Ctor
        public HomeController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public IRoleService _roleService { get; }
        #endregion
        public  IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllUsers()
        {
            return View();
        }
    }
}
