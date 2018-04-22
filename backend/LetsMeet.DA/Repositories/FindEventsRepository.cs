using System.Collections.Generic;
using System.Linq;
using LetsMeet.DA.Dto;
using LetsMeet.DA.Interfaces;
using AutoMapper;
using LetsMeet.DA.Models;
using Microsoft.EntityFrameworkCore;
using System;

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
            result.ForEach(i => i.Description = "");
            return _mapper.Map<List<EventDto>>(result);
        }

        public IEnumerable<EventDto> GetByTitle(string title)
        {
            var events = _context.Events.Where(x => x.Title == title).ToList();
            events.ForEach(i => i.Description = "");
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

            foreach (var item in eventsInDB)
            {
                var user = _context.Users.Single(n => n.Id.Equals(item.HostId));
                item.HostId = user.UserName;
            }

            for (int i = 0; i < result.Count; i++)
            {
                result[i].HostName = eventsInDB[i].HostId;
            }

            return result;
        }

        public List<EventWithHostNameDto> GetEventsWithHostNames(string title)
        {
            var wantedEvents = _context.Events.Where(n => n.Title == title).ToList();
            var result = _mapper.Map<List<EventWithHostNameDto>>(wantedEvents);

            foreach (var item in wantedEvents)
            {
                var user = _context.Users.Single(n => n.Id.Equals(item.HostId));
                item.HostId = user.UserName;
            }

            for (int i = 0; i < result.Count; i++)
            {
                result[i].HostName = wantedEvents[i].HostId;
            }

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
            const int PopularEventsNumber = 3;
            var popularEvents = from p in _context.Participants.GroupBy(p => p.EventId)
                                select new
                                {
                                    count = p.Count(),
                                    p.First().EventId
                                };

            Dictionary<int,int> popularEventsDict = new Dictionary<int, int>();
            foreach (var item in popularEvents)
            {
                popularEventsDict.Add(item.EventId, item.count);
            }
            var sortedDict = from item in popularEventsDict orderby item.Value descending select item;

            var indexList = new List<int>();
            foreach(var item in sortedDict)
            {
                indexList.Add(item.Key);
            }

            var eventsList = new List<Event>();
            for(int i=0;i<PopularEventsNumber;i++)
            {
                eventsList.Add(_context.Events.Single(n => n.Id == indexList[i]));
            }

            var result = _mapper.Map<List<EventWithHostNameDto>>(eventsList);

            foreach (var item in eventsList)
            {
                var user = _context.Users.Single(n => n.Id.Equals(item.HostId));
                item.HostId = user.UserName;
            }

            for (int i = 0; i < result.Count; i++)
            {
                result[i].HostName = eventsList[i].HostId;
            }
            return result;
        }
    }
}