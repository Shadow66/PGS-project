using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using LetsMeet.DA.Models;

namespace LetsMeet.DA.Dto
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventDto>();
            CreateMap<EventDto, Event>();
            CreateMap<Event, EventWithHostNameDto>()
                .ForMember(dest => dest.HostName, opt => opt.MapFrom(src => src.User.UserName));
            CreateMap<User, AccountRegisterLoginDto>();
            CreateMap<AccountRegisterLoginDto, User>();
            CreateMap<List<Participant>, List<EventWithHostNameDto>>();
        }
    }
}