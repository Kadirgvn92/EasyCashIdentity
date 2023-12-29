﻿using EasyCashIdentity.BusinessLayer.Abstract;
using EasyCashIdentity.DataAccessLayer.Abstract;
using EasyCashIdentity.DataAccessLayer.Concrete;
using EasyCashIdentity.DtoLayer.Dtos.CustomerAccountProcessDtos;
using EasyCashIdentity.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentity.PresentationLayer.Controllers;
public class SendMoneyController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ICustomerAccountProcessService _customerAccountProcessService;
    public SendMoneyController(UserManager<AppUser> userManager, ICustomerAccountProcessService customerAccountProcessService)
    {
        _customerAccountProcessService = customerAccountProcessService;
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(SendMoneyForCustomerAccountProcessDto sendMoneyForCustomerAccountProcessDto)
    {
        var context = new Context();

        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        var receiverAccountNumberID = context.CustomerAccounts.Where(
            x => x.CustomerAccountNumber == sendMoneyForCustomerAccountProcessDto.ReceiverAccountNumber).Select(
            y => y.CustomerAccountID).FirstOrDefault();

        sendMoneyForCustomerAccountProcessDto.SenderID = user.Id;
        sendMoneyForCustomerAccountProcessDto.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        sendMoneyForCustomerAccountProcessDto.ProcessType = "Havale";
        sendMoneyForCustomerAccountProcessDto.ReceiverID = receiverAccountNumberID;

        var values = new CustomerAccountProcess();
        values.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        values.SenderID = 6;
        values.ReceiverID = receiverAccountNumberID;
        values.ProcessType = "Havale";
        values.Amount = sendMoneyForCustomerAccountProcessDto.Amount;

        _customerAccountProcessService.TInsert(values);

        return RedirectToAction("Index", "Deneme");
    }
}
