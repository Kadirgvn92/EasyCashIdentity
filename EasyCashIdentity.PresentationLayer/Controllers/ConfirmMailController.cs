using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentity.PresentationLayer.Controllers;
public class ConfirmMailController : Controller
{
	[HttpGet]
	public IActionResult Index()
	{
		var value = TempData["Mail"];
		ViewBag.v = value + "aa";
		return View();
	}
	[HttpPost]
	public IActionResult Index(ConfirmMailController confirmMailController)
	{
		return View();
	}
}
