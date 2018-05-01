using System.Collections.Generic;
using LetsMeet.BL.Interfaces;
using LetsMeet.BL.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LetsMeet.Api.Controllers
{
    //[Produces("application/json")]
    //[Route("api/Events")]
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        private readonly IFindEventsService _iFindEventsService;

        public EventsController(IFindEventsService iFindEventsService)
        {
            _iFindEventsService = iFindEventsService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_iFindEventsService.GetAll());
        }

        [HttpGet("{title}")]
        public IActionResult GetByTitle(string title)
        {
            return Ok(_iFindEventsService.GetByTitle(title));
        }

        
        [HttpGet("GetEventDescription/{id}")]
        public IActionResult GetEventDescription(int id)
        {
            return Ok(_iFindEventsService.GetEventDescription(id));
        }

        [HttpGet("GetEventsWithHostNames"), Authorize]
        public IActionResult GetEventsWithHostNames()
        {
            return Ok(_iFindEventsService.GetEventsWithHostNames());
        }

        [HttpPut]
        public IActionResult UpdateEvent([FromBody] EventViewModel updated)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _iFindEventsService.UpdateEvent(updated);

            return Ok();
        }

        [HttpPost]
        public IActionResult AddEvent([FromBody] EventViewModel newEvent)
        {
            _iFindEventsService.AddEvent(newEvent);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(int id)
        {
            _iFindEventsService.DeleteEvent(id);
            return Ok();
        }
    }
}