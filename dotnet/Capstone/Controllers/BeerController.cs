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
    public class BeerController:ControllerBase
    {
        private readonly IBreweryDao breweryDao;
        public BeerController(IBreweryDao _breweryDao)
        {
            breweryDao = _breweryDao;
        }

        [HttpGet("{breweryName}")]
        [AllowAnonymous]
        public IActionResult GetBeersByBreweryName(string breweryName)
        {
            List<Beer> beers = breweryDao.GetBeersByBreweryName(breweryName);

            if (beers != null && beers.Count > 0)
            {
                return Ok(beers);
            }
            else
            {
                return BadRequest("Database not responding");
            }
        }
    }
}
