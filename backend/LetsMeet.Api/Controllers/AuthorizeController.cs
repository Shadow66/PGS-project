using System.Linq;
using System.Security.Claims;
using LetsMeet.BL.Interfaces;
using LetsMeet.BL.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

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

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody]AccountRegisterLoginViewModel model)
        {
            IActionResult response = Unauthorized();
            var userViewModel = _iAuthorizedService.Authenticate(model);
            if (userViewModel != null)
            {
                var tokenString = _iAuthorizedService.BuildToken(userViewModel);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        [HttpGet, Authorize]
        public IActionResult GetEmailOfLogInUser()
        {
            var currentUser = HttpContext.User;
            var email = currentUser.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            return Ok(email);
        }


    }
}