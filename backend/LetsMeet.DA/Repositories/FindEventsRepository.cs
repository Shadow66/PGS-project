using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetsMeet.DA.Dto;
using LetsMeet.DA.Interfaces;
using AutoMapper;
using LetsMeet.DA.Models;

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
            //var result = _context.Events.First();
            //var result1 = Mapper.Map<EventDto>(result);

            //int a = 5;
            //return null;

            //var result = _context.Events.ToList().ConvertToDto();
            var result = _context.Events.ToList();
            var result2 = _mapper.Map<EventDto>(result);
            return null;


        }

        public IEnumerable<EventDto> GetByTitle(string title)
        {
           // _context.Events.
            return null;
        }
    }
}
