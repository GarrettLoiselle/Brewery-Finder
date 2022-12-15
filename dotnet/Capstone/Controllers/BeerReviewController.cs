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
    public class BeerReviewController : ControllerBase
    {
        private readonly IBeerReviewDao beerReviewDao;
        public BeerReviewController(IBeerReviewDao _beerReviewDao)
        {
            beerReviewDao = _beerReviewDao;
        }
        [HttpGet("{beerId}")]
        [AllowAnonymous]
        public IActionResult GetBeerReviewsByBeerId(int beerId)
        {
            List<BeerReview> beerReviews = beerReviewDao.GetBeerReviewsByBeerId(beerId);

            if (beerReviews != null)
            {
                return Ok(beerReviews);
            }
            else
            {
                return BadRequest("Database not responding");
            }
        }

        [HttpPost("{beerId}")]
        [AllowAnonymous]
        public IActionResult AddBeerReview(int beerId,BeerReview beerReview)
        {
            bool result = beerReviewDao.AddBeerReview(beerReview);

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
