﻿using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.LoginDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> manager)
        {
            _signInManager = manager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginUserDto loginUserDto)
        {
            if (ModelState.IsValid)
            {
                // lockout ve persistant kapalı
                Console.WriteLine(loginUserDto.Username,1234,loginUserDto.Password);


                var result = await _signInManager.PasswordSignInAsync(loginUserDto.Username, loginUserDto.Password,false,false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Staff");
                }
                else
                {
                    return View();
                }
            }
            Console.WriteLine(loginUserDto.Username, 45, loginUserDto.Password);
            return View();
        }
    }
}