using EasyCashIdentity.BusinessLayer.Abstract;
using EasyCashIdentity.DataAccessLayer.Concrete;
using EasyCashIdentity.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentity.PresentationLayer.Controllers;
public class AccountListController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ICustomerAccountService _customerAccountService;

    public AccountListController(UserManager<AppUser> userManager, ICustomerAccountService customerAccountService)
    {
        _userManager = userManager;
        _customerAccountService = customerAccountService;
    }

    public async Task<IActionResult> Index()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        var context = new Context();
        var values = _customerAccountService.TGetCustomerAccountList(user.Id);
        return View(values);
    }
}
