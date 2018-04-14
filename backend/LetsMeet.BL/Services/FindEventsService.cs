using System;
using System.Collections.Generic;
using System.Text;
using LetsMeet.BL.Interfaces;
using LetsMeet.BL.ViewModel;
using LetsMeet.DA.Interfaces;

namespace LetsMeet.BL.Services
{
    public class FindEventsService : IFindEventsService
    {
        private readonly IFindEventsRepository _iFindEventsRepository;

        public FindEventsService(IFindEventsRepository iFindEventsRepository)
        {
            _iFindEventsRepository = iFindEventsRepository;
        }
        public List<EventViewModel> GetAll()
        {
            _iFindEventsRepository.GetAll();
            return null;
            
        }

        public List<EventViewModel> GetByTitle(string title)
        {
            throw new NotImplementedException();
        }
    }
}
