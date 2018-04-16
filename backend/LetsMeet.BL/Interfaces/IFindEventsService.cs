using System.Collections.Generic;
using LetsMeet.BL.ViewModel;

namespace LetsMeet.BL.Interfaces
{
    public interface IFindEventsService
    {
        List<EventViewModel> GetAll();
        List<EventViewModel> GetByTitle(string title);
        void UpdateEvent(EventViewModel updated);
        void AddEvent(EventViewModel newEvent);


    }
}