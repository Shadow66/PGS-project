using System.Collections.Generic;
using LetsMeet.BL.ViewModel;

namespace LetsMeet.BL.Interfaces
{
    public interface IFindEventsService
    {
        List<EventViewModel> GetAll();
        List<EventViewModel> GetByTitle(string title);
        void UpdateEvent(EventViewModel updated, string email);
        void AddEvent(EventViewModel newEvent, string email);
        void DeleteEvent(int id, string email);
        string GetEventDescription(int id);
        List<EventWithHostNameViewModel> GetEventsWithHostNames();
        List<EventWithHostNameViewModel> GetEventsWithHostNames(string title);
        EventWithHostNameViewModel GetEventWithHostName(int id);
        IEnumerable<string> GetUsersAssignedToEvent(int id);
        int GetNumberEventParticipants(int id);
        List<EventWithHostNameViewModel> GetMostPopularEvents();
        void JoinToEvent(int id, string email);
        bool IsAssignedToEvent(int id, string email);
        void LeaveEvent(int id, string email);
        List<EventWithHostNameViewModel> GetMyCreatedEvents(string email);
        List<EventWithHostNameViewModel> GetEventsAssignedToLoggedUser(string email);
    }
}