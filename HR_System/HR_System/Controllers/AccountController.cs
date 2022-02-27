using HR_System.Models;
using HR_System.service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_System.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService _accountService)
        {
            accountService = _accountService;
        }
        public IActionResult Index()
        {
            return View("Register");
        }

        public async Task<IActionResult> Create(RegisterModel registerModel)
        {
            var result = await accountService.create(registerModel);
            return View("Register",registerModel);
        }

        public IActionResult SignIn()
        {
            return View();
        }

        public async Task<IActionResult> Login(LoginModel login)
        {
            var result = await accountService.Login(login);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                ViewData["ErrorMessage"] = "Invalid Username or Password";
            }
            return View("SignIn");
        }

        public async Task<IActionResult> SignOut()
        {
            await accountService.SignOut();
            return View("SignIn");
        }
    }
}
