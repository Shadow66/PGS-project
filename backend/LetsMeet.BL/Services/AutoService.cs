using System;
using System.Collections.Generic;
using System.Text;
using LetsMeet.DA.Models;
using Microsoft.AspNetCore.Identity;

namespace LetsMeet.BL.Services
{
    class AuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly PasswordHasher<User> _passwordHasher;

        public void Test()
        {
        }
    }
}
