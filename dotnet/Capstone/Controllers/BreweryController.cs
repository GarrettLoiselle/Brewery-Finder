using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class BreweryController : ControllerBase
    {
        private readonly IBreweryDao breweryDao;
        public BreweryController(IBreweryDao _breweryDao)
        {
            breweryDao = _breweryDao;
        }
        [HttpGet()]
        [AllowAnonymous]
        public IActionResult GetAllBreweries()
        {
            List<Brewery> breweries = breweryDao.GetAllBreweries();

            if (breweries != null && breweries.Count > 0)
            {
                return Ok(breweries);
            }
            else
            {
                return BadRequest("Database not responding");
            }
        }
        [HttpGet("{breweryId}")]
        [AllowAnonymous]
        public IActionResult GetBreweryById(int breweryId)
        {
            Brewery brewery = breweryDao.GetBreweryById(breweryId);

            if (brewery != null && brewery.BreweryId > 0)
            {
                return Ok(brewery);
            }
            else
            {
                return BadRequest("Database not responding");
            }
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AddBrewery(Brewery brewery)
        {
            bool result = breweryDao.AddBrewery(brewery);

            if(result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut("{breweryId}")]
        [Authorize(Roles = "admin,brewer")]
        public IActionResult UpdateBrewery(int breweryId, Brewery brewery)
        {
           
            bool result = breweryDao.UpdateBrewery(brewery);

            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
