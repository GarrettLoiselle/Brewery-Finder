using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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
            List<FileUpload> files=fileDao.GetFilesBasedOnBreweryId(breweryId);
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
            List<FileUpload> actualFiles = new List<FileUpload>();
            bool result=false;
            foreach(IFormFile item in files)
            {
                FileUpload file = new FileUpload();
                using (var memoryStream = new MemoryStream())
                {
                    // FileUpload.FormFile.CopyToAsync(memoryStream);
                   
                    // Upload the file if less than 2 MB
                    if (memoryStream.Length < 2097152)
                    {
                        {
                            file.Content = memoryStream.ToArray();
                        }

  //                      _dbContext.File.Add(file);
//
    //                     _dbContext.SaveChangesAsync();
                    }
                    else
                    {
                        ModelState.AddModelError("File", "The file is too large.");
                    }
                };
                file.BreweryId = breweryId;
                file.FileName = item.FileName;
                actualFiles.Add(file);

            }
            foreach(FileUpload item in actualFiles)
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
