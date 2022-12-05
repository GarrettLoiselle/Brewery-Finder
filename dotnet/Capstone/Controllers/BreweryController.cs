﻿using Capstone.DAO;
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
    public class BreweryController:ControllerBase
    {
        private readonly IBreweryDao breweryDao;
        public BreweryController(IBreweryDao _breweryDao)
        {
            breweryDao = _breweryDao;
        }
        [HttpGet()]
        [AllowAnonymous]
        public IActionResult GetAllBrewerys()
        {
            List<Brewery> brewerys = breweryDao.GetAllBrewerys();

            if (brewerys != null && brewerys.Count > 0)
            {
                return Ok("Server? Ready with " + brewerys.Count + " brewery(s).");
            }
            else
            {
                return BadRequest("Database not responding");
            }
        }
    }
}