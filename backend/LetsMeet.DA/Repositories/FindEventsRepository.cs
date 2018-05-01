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
            var result = _context.Events.ToList();
            return _mapper.Map<List<EventDto>>(result);
        }

        public IEnumerable<EventDto> GetByTitle(string title)
        {
            var events = _context.Events.Where(x => x.Title == title).ToList();
            var result = _mapper.Map<IEnumerable<EventDto>>(events);
            return result;
        }

        public string GetEventDescription(int id)
        {
            var eventInDb = _context.Events.SingleOrDefault(n => n.Id == id);
            var result = eventInDb.Description;
            return result;
        }

        public List<EventWithHostNameDto> GetEventsWithHostNames()
        {
            var eventsInDB = _context.Events.ToList();
            var result = _mapper.Map<List<EventWithHostNameDto>>(eventsInDB);

            foreach(var item in eventsInDB)
            {
                var user = _context.Users.Single(n => n.Id.Equals(item.HostId));
                item.HostId = user.UserName;
            }

            for(int i=0;i<result.Count;i++)
            {
                result[i].HostName = eventsInDB[i].HostId;
            }
        
            return result;

        }

        public void UpdateEvent(EventDto updated)
        {
            var eventObject =_mapper.Map<Event>(updated);
            var eventInDb = _context.Events.Single(n => n.Id == eventObject.Id);
            _context.Entry(eventInDb).CurrentValues.SetValues(eventObject);
        
            _context.SaveChanges();
        }

        public void AddEvent(EventDto newEvent)
        {
            var eventObject = _mapper.Map<Event>(newEvent);
            _context.Events.Add(eventObject);
            _context.SaveChanges();
        }

        public void DeleteEvent(int id)
        {
            var eventInDb = _context.Events.SingleOrDefault(n => n.Id == id);
            _context.Events.Remove(eventInDb);
            _context.SaveChanges();
        }
    }
}