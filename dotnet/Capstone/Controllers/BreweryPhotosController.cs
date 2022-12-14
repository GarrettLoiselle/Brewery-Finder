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
    public class BreweryPhotosController : ControllerBase
    {
        
        
            private readonly IBreweryPhotosDao photosDao;
            public BreweryPhotosController(IBreweryPhotosDao _photosDao)
            {
                photosDao = _photosDao;
            }

            [HttpGet("{breweryId}")]
            [AllowAnonymous]
            public IActionResult GetPhotosByBreweryId(int breweryId)
            {
                List<BreweryPhotos> photos = photosDao.GetPhotosByBreweryId(breweryId);

                if (photos != null && photos.Count > 0)
                {
                    return Ok(photos);
                }
                else
                {
                    return BadRequest("Database not responding");
                }
            }
        
    }
}
