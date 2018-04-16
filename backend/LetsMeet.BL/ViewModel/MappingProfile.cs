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
        }
    }
}