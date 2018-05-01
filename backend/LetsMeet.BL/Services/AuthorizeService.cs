using AutoMapper;
using LetsMeet.BL.Interfaces;
using LetsMeet.BL.ViewModel;
using LetsMeet.DA.Dto;
using LetsMeet.DA.Interfaces;

namespace LetsMeet.BL.Services
{
    public class AuthorizeService : IAuthorizeService
    {
        private readonly IAuthorizeRepository _authorizeRepository;
        private readonly IMapper _mapper;

        public AuthorizeService(IAuthorizeRepository findEventsRepository, IMapper mapper)
        {
            _authorizeRepository = findEventsRepository;
            _mapper = mapper;
        }

        public void Create(AccountRegisterLoginViewModel model)
        {
            var accountDto = _mapper.Map<AccountRegisterLoginDto>(model);
            _authorizeRepository.CreateAsync(accountDto);
        }

        public AccountRegisterLoginViewModel Authenticate(AccountRegisterLoginViewModel accountRegisterLoginViewModel)
        {
            var accountRegisterLoginDto = _mapper.Map<AccountRegisterLoginDto>(accountRegisterLoginViewModel);
            var userDto = _authorizeRepository.Authenticate(accountRegisterLoginDto);
            var result = _mapper.Map<AccountRegisterLoginViewModel>(userDto.Result);
            return result;
        }

        public string BuildToken(AccountRegisterLoginViewModel accountRegisterViewModel)
        {
            var userDto = _mapper.Map<AccountRegisterLoginDto>(accountRegisterViewModel);
            var token = _authorizeRepository.BuildToken(userDto);
            return token;
        }
    }
}

