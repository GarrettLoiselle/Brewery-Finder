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
        private readonly IBeerDao beerDao;
        public BeerController(IBeerDao _beerDao)
        {
            beerDao = _beerDao;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllBeers()
        {
            List<Beer> beers = beerDao.GetAllBeers();

            if (beers != null && beers.Count > 0)
            {
                return Ok(beers);
            }
            else
            {
                return BadRequest("Database not responding");
            }
        }

        [HttpGet("{breweryId}")]
        [AllowAnonymous]
        public IActionResult GetBeersByBreweryId(int breweryId)
        {
            List<Beer> beers = beerDao.GetBeersByBreweryId(breweryId);

            if (beers != null && beers.Count > 0)
            {
                return Ok(beers);
            }
            else
            {
                return BadRequest("Database not responding");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult AddBeer(Beer beer)
        {
            decimal beerId = beerDao.AddBeer(beer);
            bool result = beerDao.AddBeerConn(beerId, beer.BreweryId);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut("{beerId}")]
        [AllowAnonymous]
        public IActionResult UpdateBeer(int beerId, Beer beer)
        {
            bool result = beerDao.UpdateBeer(beer);

            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("{beerId}")]
        [AllowAnonymous]
        public IActionResult DeleteBeer(int beerId)
        {
            bool result = beerDao.DeleteBeer(beerId);

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
