using EasyCashIdentity.BusinessLayer.Abstract;
using EasyCashIdentity.DataAccessLayer.Concrete;
using EasyCashIdentity.DtoLayer.Dtos.CustomerAccountProcessDtos;
using EasyCashIdentity.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SelectPdf;

namespace EasyCashIdentity.PresentationLayer.Controllers;


public class PdfController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ICustomerAccountProcessService _customerAccountProcessService;

    public PdfController(UserManager<AppUser> userManager, ICustomerAccountProcessService customerAccountProcessService) 
    {
        _userManager = userManager;
        _customerAccountProcessService = customerAccountProcessService;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View();
    }
}
