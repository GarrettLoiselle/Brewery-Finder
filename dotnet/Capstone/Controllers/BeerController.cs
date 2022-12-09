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

        [HttpGet("{breweryName}")]
        [AllowAnonymous]
        public IActionResult GetBeersByBreweryName(string breweryName)
        {
            List<Beer> beers = beerDao.GetBeersByBreweryName(breweryName);

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
            bool result = beerDao.AddBeer(beer);

            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [AllowAnonymous]
        public IActionResult UpdateBeer(Beer beer)
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
        [HttpDelete]
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
