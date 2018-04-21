using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetsMeet.BL.Interfaces;
using LetsMeet.BL.ViewModel;
using LetsMeet.DA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LetsMeet.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthorizeController : Controller
    {
        private SignInManager<User> _signManager;
        private UserManager<User> _userManager;
        private readonly IAuthorizeService _iAuthorizedService;

        public AuthorizeController(IAuthorizeService iAuthorizedService,
            UserManager<User> userManager,
            SignInManager<User> signManager
            )
        {
            _iAuthorizedService = iAuthorizedService;
            _userManager = userManager;
            _signManager = signManager;
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

        [HttpPost]
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
        }

        [Authorize, HttpGet]
        public IActionResult GetOk()
        {
            return Ok();
        }
    }
}