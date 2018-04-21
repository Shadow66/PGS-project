using LetsMeet.DA.Dto;
using LetsMeet.DA.Interfaces;
using LetsMeet.DA.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LetsMeet.DA.Repositories
{
    public class AuthorizeRepository : IAuthorizeRepository
    {
        private SignInManager<User> _signManager;
        private UserManager<User> _userManager;

        public AuthorizeRepository( 
            UserManager<User> userManager,
            SignInManager<User> signManager)
        {
            _userManager = userManager;
            _signManager = signManager;
        }
        public async Task CreateAsync(AccountRegisterLoginDto model)
        {
            User user = new User
            {
                UserName = model.Email,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            
        }

        public async Task LogInAsync(AccountRegisterLoginDto model)
        {
           
            try
            {   
                var result = await _signManager.PasswordSignInAsync(model.Email, model.Password, false, false);
              
            }
            catch(Exception e)
            {
                
            }
          
        }
    }
}
