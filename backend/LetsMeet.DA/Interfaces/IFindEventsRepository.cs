using System.Collections.Generic;
using LetsMeet.DA.Dto;

namespace LetsMeet.DA.Interfaces
{
    public interface IFindEventsRepository
    {
        IEnumerable<EventDto> GetAll();
        IEnumerable<EventDto> GetByTitle(string title);
        void UpdateEvent(EventDto updated);
        void AddEvent(EventDto newEvent);
        void DeleteEvent(int id);
        string GetEventDescription(int id);
        List<EventWithHostNameDto> GetEventsWithHostNames();
        List<EventWithHostNameDto> GetEventWithHostName(string title);
        int GetNumberEventParticipants(int id);
    }
}