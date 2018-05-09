using LetsMeet.DA.Dto;
using LetsMeet.DA.Interfaces;
using LetsMeet.DA.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Linq;

namespace LetsMeet.DA.Repositories
{
    public class AuthorizeRepository : IAuthorizeRepository
    {
        private readonly ApplicationDbContext _context;
        private SignInManager<User> _signManager;
        private UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private IConfiguration _config;

        public AuthorizeRepository(
            ApplicationDbContext context,
            UserManager<User> userManager,
            SignInManager<User> signManager,
            IConfiguration config,
            IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _signManager = signManager;
            _config = config;
            _mapper = mapper;
        }

        public async Task CreateAsync(AccountRegisterLoginDto model)
        {
            var user = _mapper.Map<User>(model);
            user.UserName = model.Email;

            var result = await _userManager.CreateAsync(user, model.Password);
        }

        public async Task<string> CreateToken(AccountRegisterLoginDto accountRegisterLoginDto)
        {
            var user = await _userManager.FindByEmailAsync(accountRegisterLoginDto.Email);
            if (user == null)
            {
                return null;
            }
            var signInResult = await _signManager.CheckPasswordSignInAsync(user, accountRegisterLoginDto.Password, false);
            if (!signInResult.Succeeded)
            {
                return null;
            }
            return BuildToken(accountRegisterLoginDto);
        }

        private string BuildToken(AccountRegisterLoginDto user)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
