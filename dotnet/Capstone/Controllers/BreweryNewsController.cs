using Capstone.DAO.Interfaces;
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
    public class BreweryNewsController : ControllerBase
    {
        private readonly IBreweryNewsDao newsDao;
        public BreweryNewsController(IBreweryNewsDao _newsDao)
        {
            newsDao = _newsDao;
        }

        [HttpGet("{breweryId}")]
        [AllowAnonymous]
        public IActionResult GetNewsByBreweryId(int breweryId)
        {
            List<BreweryNews> news = newsDao.GetNewsByBreweryId(breweryId);

            if (news != null && news.Count > 0)
            {
                return Ok(news);
            }
            else
            {
                return BadRequest("Database not responding");
            }
        }
    }
}
