using System.Collections.Generic;
using System.Linq;
using LetsMeet.DA.Dto;
using LetsMeet.DA.Interfaces;
using AutoMapper;

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
            return _mapper.Map<List<EventDto>>(result);
        }

        public IEnumerable<EventDto> GetByTitle(string title)
        {
            // _context.Events.
            return null;
        }
    }
}