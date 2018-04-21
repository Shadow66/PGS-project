using LetsMeet.BL.Interfaces;
using LetsMeet.BL.ViewModel;
using LetsMeet.DA.Dto;
using LetsMeet.DA.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LetsMeet.BL.Services
{
    public class AuthorizeService : IAuthorizeService
    {
        private readonly IAuthorizeRepository _authorizeRepository;

        public AuthorizeService(IAuthorizeRepository findEventsRepository)
        {
            _authorizeRepository = findEventsRepository;
        }

        public void Create(AccountRegisterLoginViewModel model)
        {
            var accountDto = new AccountRegisterLoginDto
            {
                Email = model.Email,
                Password = model.Password
            };

            _authorizeRepository.CreateAsync(accountDto);
        }

        public void LogIn(AccountRegisterLoginViewModel model)
        {
            var accountDto = new AccountRegisterLoginDto
            {
                Email = model.Email,
                Password = model.Password
            };

            _authorizeRepository.LogInAsync(accountDto);
        }
    }
}

