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
        private readonly IFindEventsRepository _findEventsRepository;
        private readonly IMapper _mapper;

        public FindEventsService(IFindEventsRepository findEventsRepository, IMapper mapper)
        {
            _findEventsRepository = findEventsRepository;
            _mapper = mapper;
        }
        public List<EventViewModel> GetAll()
        {
            var result = _findEventsRepository.GetAll();
            return _mapper.Map<List<EventViewModel>>(result);
        }

        public List<EventViewModel> GetByTitle(string title)
        {
            var result = _findEventsRepository.GetByTitle(title);
            return _mapper.Map<List<EventViewModel>>(result);
        }

        public void UpdateEvent(EventViewModel updated)
        {
            var eventDtoObject =_mapper.Map< EventDto > (updated);
            _findEventsRepository.UpdateEvent(eventDtoObject);
        }

        public void AddEvent(EventViewModel newEvent)
        {
            var eventDtoObject = _mapper.Map<EventDto>(newEvent);
            _findEventsRepository.AddEvent(eventDtoObject);
        }

        public void DeleteEvent(int id)
        {
            _findEventsRepository.DeleteEvent(id);
        }
    }
}
