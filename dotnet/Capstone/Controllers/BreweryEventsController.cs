using Capstone.DAO.Interfaces;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class BreweryEventsController : ControllerBase
    {
        private readonly IBreweryEventsDao eventsDao;

        public BreweryEventsController(IBreweryEventsDao _eventsDao)
        {
            eventsDao = _eventsDao;
        }

        [HttpGet("{breweryId}")] 
        [AllowAnonymous]

        public IActionResult GetEventsByBreweryId(int breweryId)
        {
            List<BreweryEvents> events = eventsDao.GetEventsByBreweryId(breweryId);

            if (events != null && events.Count > 0)
            {
                return Ok(events);
            }
            else
            {
                return BadRequest("Database not responding");
            }

        }
    }
}
