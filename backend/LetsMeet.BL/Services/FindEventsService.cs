using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using LetsMeet.BL.Interfaces;
using LetsMeet.BL.ViewModel;
using LetsMeet.DA.Dto;
using LetsMeet.DA.Interfaces;
using System.Linq;

namespace LetsMeet.BL.Services
{
    public class FindEventsService : IFindEventsService
    {
        private readonly IFindEventsRepository _iFindEventsRepository;
        private readonly IMapper _mapper;

        public FindEventsService(IFindEventsRepository iFindEventsRepository, IMapper mapper)
        {
            _iFindEventsRepository = iFindEventsRepository;
            _mapper = mapper;
        }
        public List<EventViewModel> GetAll()
        {
            var result = _iFindEventsRepository.GetAll();
            return _mapper.Map<List<EventViewModel>>(result);
        }

        public List<EventViewModel> GetByTitle(string title)
        {
            var result = _iFindEventsRepository.GetByTitle(title);
            var selectedResult = result.Where(n => n.Title.Equals(title));
            return _mapper.Map<List<EventViewModel>>(selectedResult);
        }

        public void UpdateEvent(EventViewModel updated)
        {
            var eventDtoObject =_mapper.Map< EventDto > (updated);
            _iFindEventsRepository.UpdateEvent(eventDtoObject);
        }

        public void AddEvent(EventViewModel newEvent)
        {
            var eventDtoObject = _mapper.Map<EventDto>(newEvent);
            _iFindEventsRepository.AddEvent(eventDtoObject);
        }
    }
}
