using AutoMapper;
using LetsMeet.DA.Dto;

namespace LetsMeet.BL.ViewModel
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EventDto, EventViewModel>();
            CreateMap<EventViewModel, EventDto>();
            CreateMap<EventWithHostNameDto, EventWithHostNameViewModel>();
            CreateMap<AccountRegisterLoginViewModel, AccountRegisterLoginDto>();
            CreateMap<AccountRegisterLoginDto, AccountRegisterLoginViewModel>();
        }
    }
}