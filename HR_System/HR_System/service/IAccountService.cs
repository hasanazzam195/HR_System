using HR_System.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_System.service
{
    public interface IAccountService
    {
        Task<IdentityResult> create(RegisterModel register);
        Task<SignInResult> Login(LoginModel login);
        Task SignOut();
    }
}
