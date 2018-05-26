using System.Collections.Generic;
using LetsMeet.DA.Dto;

namespace LetsMeet.DA.Interfaces
{
    public interface IFindEventsRepository
    {
        IEnumerable<EventDto> GetAll();
        IEnumerable<EventDto> GetByTitle(string title);
        void UpdateEvent(EventDto updated, string email);
        void AddEvent(EventDto newEvent, string email);
        void DeleteEvent(int id, string email);
        string GetEventDescription(int id);
        List<EventWithHostNameDto> GetEventsWithHostNames();
        List<EventWithHostNameDto> GetEventsWithHostNames(string title);
        EventWithHostNameDto GetEventWithHostName(int id);
        int GetNumberEventParticipants(int id);
        IEnumerable<string> GetUsersAssignedToEvent(int id);
        List<EventWithHostNameDto> GetMostPopularEvents();
        void JoinToEvent(int eventId, string email);
        bool IsAssignedToEvent(int id, string email);
        void LeaveEvent(int id, string email);
    }
}