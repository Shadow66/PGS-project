﻿using System.Collections.Generic;
using LetsMeet.BL.Interfaces;
using LetsMeet.BL.ViewModel;
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
        public List<EventViewModel> Get()
        {
            return _iFindEventsService.GetAll();
        }
    }
}