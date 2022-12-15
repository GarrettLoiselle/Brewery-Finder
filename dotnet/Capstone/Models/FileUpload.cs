using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Capstone.Models
{
    public class FileUpload
    {
        public int BreweryId { get; set; }
        public string FileName { get; set; }
        public int FileId { get; set; }
        public byte[] Content { get; set; }
    }
}
