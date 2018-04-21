using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetsMeet.BL.Interfaces;
using LetsMeet.BL.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LetsMeet.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthorizeController : Controller
    {
        private readonly IAuthorizeService _iAuthorizedService;

        public AuthorizeController(IAuthorizeService iAuthorizedService)
        {
            _iAuthorizedService = iAuthorizedService;
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
        public IActionResult LogIn([FromBody] AccountRegisterLoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(modelError => modelError.ErrorMessage).ToList());
            }

            _iAuthorizedService.LogIn(model);

            return Ok();
        }

        [HttpGet]
        public IActionResult GetOk()
        {
            return Ok();
        }
    }
}