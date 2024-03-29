﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebCoreMvc.ApiServices.Interfaces;

namespace WebCoreMvc.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class UserController : Controller
    {
        private IUserApiService _userApiService;
        private IHttpContextAccessor _httpContextAccessor;
        public UserController(IUserApiService userApiService, IHttpContextAccessor httpContextAccessor)
        {
            _userApiService = userApiService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
           // return BadRequest();
            return View( await _userApiService.GetListAsync());
        }
    }
}
