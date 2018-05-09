using System.Threading.Tasks;
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

        public async Task Create(AccountRegisterLoginViewModel model)
        {
            var accountDto = _mapper.Map<AccountRegisterLoginDto>(model);
            await _authorizeRepository.CreateAsync(accountDto);
        }

        public Task<string> CreateToken(AccountRegisterLoginViewModel accountRegisterLoginViewModel)
        {
            var accountRegisterLoginDto = _mapper.Map<AccountRegisterLoginDto>(accountRegisterLoginViewModel);
            var result = _authorizeRepository.CreateToken(accountRegisterLoginDto);
            return result;
        }
    }
}

