using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using LetsMeet.BL.Interfaces;
using LetsMeet.BL.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LetsMeet.Api.Controllers
{
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

        [HttpGet("GetEventsWithHostNames")]
        public IActionResult GetEventsWithHostNames()
        {
            return Ok(_iFindEventsService.GetEventsWithHostNames());
        }

        [HttpGet("GetEventsWithHostNames/{title}")]
        public IActionResult GetEventsWithHostNames(string title)
        {
            return Ok(_iFindEventsService.GetEventsWithHostNames(title));
        }

        [HttpGet("GetNumberEventParticipants/{id}")]
        public IActionResult GetNumberEventParticipants(int id)
        {
            return Ok(_iFindEventsService.GetNumberEventParticipants(id));
        }

        [HttpGet("GetMostPopularEvents")]
        public IActionResult GetMostPopularEvents()
        {
            return Ok(_iFindEventsService.GetMostPopularEvents());
        }

        [HttpPut, Authorize]
        public IActionResult UpdateEvent([FromBody] EventViewModel updated)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var email = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            _iFindEventsService.UpdateEvent(updated, email);

            return Ok();
        }

        [HttpPost, Authorize]
        public IActionResult AddEvent([FromBody] EventViewModel newEvent)
        {
            var email = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            _iFindEventsService.AddEvent(newEvent, email);
            return Ok();
        }

        [HttpDelete("{id}"), Authorize]
        public IActionResult DeleteEvent(int id)
        {
            var email = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            _iFindEventsService.DeleteEvent(id, email);
            return Ok();
        }

        [HttpPost("JoinToEvent/{id}"), Authorize]
        public IActionResult JoinToEvent(int id)
        {
            var email = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            _iFindEventsService.JoinToEvent(id, email);
            return Ok();
        }
    }
}