using EasyCashIdentity.EntityLayer.Concrete;
using EasyCashIdentity.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentity.PresentationLayer.Controllers;
public class LoginController : Controller
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;

    public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(LoginViewModel loginViewModel)
    {
        var result = await _signInManager.PasswordSignInAsync(loginViewModel.Username,loginViewModel.Password,false,true); //Bool is persisten "Beni Hatırla" anlamına                                                                                                                            gelir.LockoutOnFailure defaul olan 5 sefer yanlış                                                                                                                      şifre girişinde 5 dk. login işlemini disable yapar.
        if(result.Succeeded)
        {
            var user = await _userManager.FindByNameAsync(loginViewModel.Username);
            if (user.EmailConfirmed == true)
            {
                return RedirectToAction("Index", "MyProfile");
            }
            else
            {
                ViewBag.Message = "Lütfen üyeliğinizi email adresinden onaylayınız";
                return RedirectToAction("Index","Login");
            }
            
        }
        return View();
    }
}
