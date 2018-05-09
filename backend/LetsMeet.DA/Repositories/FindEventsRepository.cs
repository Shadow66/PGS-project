using System.Collections.Generic;
using System.Linq;
using LetsMeet.DA.Dto;
using LetsMeet.DA.Interfaces;
using AutoMapper;
using LetsMeet.DA.Models;
using Microsoft.EntityFrameworkCore;

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
            var eventsInDB = _context.Events.Include(u => u.User).ToList();
            var result = _mapper.Map<List<EventWithHostNameDto>>(eventsInDB);
            return result;
        }

        public List<EventWithHostNameDto> GetEventsWithHostNames(string title)
        {
            var wantedEvents = _context.Events.Where(n => n.Title == title).Include(u => u.User).ToList();
            var result = _mapper.Map<List<EventWithHostNameDto>>(wantedEvents);
            return result;
        }

        public int GetNumberEventParticipants(int id)
        {
            int result = _context.Participants.Count(n => n.EventId == id);
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

        public List<EventWithHostNameDto> GetMostPopularEvents()
        {
            var popularEvents = _context.Events.Include(p => p.Participants)
                .Include(u => u.User)
                .OrderByDescending(e => e.Participants.Count)
                .Take(3).ToList();
            var result = _mapper.Map<List<EventWithHostNameDto>>(popularEvents);
            return result;
        }
    }
}