using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsMeet.BL.Interfaces;
using LetsMeet.BL.ViewModel;
using LetsMeet.DA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace LetsMeet.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthorizeController : Controller
    {
        private readonly IAuthorizeService _iAuthorizedService;
        private IConfiguration _config;

        public AuthorizeController(IAuthorizeService iAuthorizedService, IConfiguration config)
        {
            _iAuthorizedService = iAuthorizedService;
            _config = config;

        }

       [HttpPost("Register")]
       public IActionResult Register([FromBody] AccountRegisterLoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(modelError => modelError.ErrorMessage).ToList());
            }

            _iAuthorizedService.Create(model);

            return Ok();
        }

        /* [HttpPost]
         public async Task<IActionResult> LogInAsync([FromBody] AccountRegisterLoginViewModel model)
         {
             if (!ModelState.IsValid)
             {
                 return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(modelError => modelError.ErrorMessage).ToList());
             }

             var result = await _signManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);

             if (!result.Succeeded)
             {
                 return BadRequest();
             }

             // _iAuthorizedService.LogIn(model);

             return Ok();
         }*/

        private User Authenticate(AccountRegisterLoginViewModel login)
        {
            User user = null;

            if (login.Email == "123@gmail.com" && login.Password == "secret")
            {
                user = new User { UserName = "tom hanks", Email = "123@gmail.com" };
            }
            return user;
        }

        private string BuildToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody]AccountRegisterLoginViewModel login)
        {
            IActionResult response = Unauthorized();
            var user = Authenticate(login);

            if (user != null)
            {
                var tokenString = BuildToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        [HttpGet, Authorize]
        public IActionResult GetOk()
        {
            return Ok();
        }
    }
}