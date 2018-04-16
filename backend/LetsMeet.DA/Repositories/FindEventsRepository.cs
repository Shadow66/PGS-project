using System.Collections.Generic;
using System.Linq;
using LetsMeet.DA.Dto;
using LetsMeet.DA.Interfaces;
using AutoMapper;
using LetsMeet.DA.Models;

namespace LetsMeet.DA.Repositories
{
    public class FindEventsRepository : IFindEventsRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FindEventsRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<EventDto> GetAll()
        {
            //var result1 = _context.Events.First()
            //var result2 = _mapper.Map<EventDto>(result1);

            var result = _context.Events.ToList();
            return _mapper.Map<List<EventDto>>(result);
        }

        public IEnumerable<EventDto> GetByTitle(string title)
        {
            var result = _context.Events.ToList();
            return _mapper.Map<List<EventDto>>(result);
        }

        public void UpdateEvent(EventDto updated)
        {
            var eventObject =_mapper.Map<Event>(updated);
            var result = _context.Events.SingleOrDefault(n => n.Id == eventObject.Id);

            result.Address = eventObject.Address;
            result.StartDate = eventObject.StartDate;
            result.EndDate = eventObject.EndDate;
            result.Title = eventObject.Title;
            result.Description = eventObject.Description;
            result.Category = eventObject.Category;
            _context.SaveChanges();
        }

        public void AddEvent(EventDto newEvent)
        {
            var eventObject = _mapper.Map<Event>(newEvent);
            _context.Events.Add(eventObject);
            _context.SaveChanges();
        }
    }
}