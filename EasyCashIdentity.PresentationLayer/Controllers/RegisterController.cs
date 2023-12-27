﻿using EasyCashIdentity.DtoLayer.Dtos.AppUserDtos;
using EasyCashIdentity.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentity.PresentationLayer.Controllers;
public class RegisterController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public RegisterController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
    {
        if(ModelState.IsValid)
        {
            Random random = new Random();

            AppUser appUser = new AppUser()
            {
                UserName = appUserRegisterDto.Username,
                Name = appUserRegisterDto.Name,
                Email = appUserRegisterDto.Email,
                Surname = appUserRegisterDto.Surname,
                City = "Bursa",
                District = "Marmara",
                ImageUrl = "image",
                ConfirmCode = random.Next(100000, 1000000)
            };

            var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index","ConfirmMail");
            }else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
        }

        return View();
    }
}