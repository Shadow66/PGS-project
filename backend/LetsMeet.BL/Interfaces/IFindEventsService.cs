﻿using System.Collections.Generic;
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
        int GetNumberEventParticipants(int id);
        List<EventWithHostNameViewModel> GetMostPopularEvents();
        void JoinToEvent(int id, string email);



    }
}