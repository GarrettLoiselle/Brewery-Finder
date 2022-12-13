using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class BreweryNews
    {
        public int NewsId { get; set; }
        public int BreweryId { get; set; }
        public string News { get; set; }
    }
}
