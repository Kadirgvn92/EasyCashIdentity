using EasyCashIdentity.DtoLayer.Dtos.AppUserDtos;
using EasyCashIdentity.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using EasyCashIdentity.PresentationLayer.Mail;

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
            int code = random.Next(100000, 1000000);

            AppUser appUser = new AppUser()
            {
                UserName = appUserRegisterDto.Username,
                Name = appUserRegisterDto.Name,
                Email = appUserRegisterDto.Email,
                Surname = appUserRegisterDto.Surname,
                City = "Bursa",
                District = "Marmara",
                ImageUrl = "image",
                ConfirmCode = code
            };

            var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);
            if (result.Succeeded)
            {
                MimeMessage mimeMessage = new MimeMessage();
                MailboxAddress mailboxAddressFrom = new MailboxAddress("Easy Cash Admin", "kadirgvn92@gmail.com");
                MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);

                mimeMessage.From.Add(mailboxAddressFrom);
                mimeMessage.To.Add(mailboxAddressTo);

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = "Kayıt işlemi gerçekleştirmek için Onay Kodunuz : " + code;
                mimeMessage.Body = bodyBuilder.ToMessageBody();

                mimeMessage.Subject = "Easy Cash Onay Kodu";

                SmtpClient smtpClient = new SmtpClient();
				smtpClient.Connect("smtp.gmail.com", 587, false);
				smtpClient.Authenticate("kadirgvn92@gmail.com", MailPassword.Password);

				smtpClient.Send(mimeMessage);
				smtpClient.Disconnect(true);

                TempData["Mail"] = appUserRegisterDto.Email;

				return RedirectToAction("Index","ConfirmMail");
            }
            else
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
