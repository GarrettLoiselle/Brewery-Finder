using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class FileController : ControllerBase
    {
        private readonly IFileDao fileDao;
        public FileController(IFileDao _fileDao)
        {
            fileDao = _fileDao;
        }

        [HttpGet("{breweryId}")]
        [AllowAnonymous]
        public IActionResult GetFilesBasedOnBreweryId(int breweryId)
        {
            List<File> files=fileDao.GetFilesBasedOnBreweryId(breweryId);
            if (files != null && files.Count > 0)
            {
                return Ok(files);
            }
            else
            {
                return BadRequest("Database not responding");
            }
        }

        [HttpPost("{breweryId}")]
        [Authorize(Roles = "admin,brewer")]
        public IActionResult AddFile(int breweryId, List<IFormFile> files)
        {
            List<File> actualFiles = new List<File>();
            bool result=false;
            foreach(IFormFile item in files)
            {
                File file = new File();
                //file.Content = item.OpenReadStrea;
                file.BreweryId = breweryId;
                file.FileName = item.FileName;
                actualFiles.Add(file);

            }
            foreach(File item in actualFiles)
            {
                result = fileDao.AddFile(item);
            }

            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{fileId}")]
        public void Delete(int fileId)
        {
        }
    }
}
