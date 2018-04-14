using System.Collections.Generic;
using LetsMeet.DA.Dto;

namespace LetsMeet.DA.Interfaces
{
    public interface IFindEventsRepository
    {
        IEnumerable<EventDto> GetAll();
        IEnumerable<EventDto> GetByTitle(string title);

    }
}