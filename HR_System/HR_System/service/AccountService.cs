using HR_System.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_System.service
{
    
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountService(UserManager<IdentityUser> _userManager,SignInManager<IdentityUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        public async Task<IdentityResult> create(RegisterModel register)
        {
            IdentityUser user = new IdentityUser();
            user.Email = register.Email;
            user.UserName = register.Email;
            var result = await userManager.CreateAsync(user, register.Password);
            return result;
        }

        public async Task<SignInResult> Login(LoginModel login)
        {
            var result = await signInManager.PasswordSignInAsync(login.Email, login.Password, false, false);
            return result;
        }

        public async Task SignOut()
        {
            await signInManager.SignOutAsync();
        }

    }
}
