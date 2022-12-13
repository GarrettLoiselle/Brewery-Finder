using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class BreweryEvents
    {
        public int EventId { get; set; }
        public int BreweryId { get; set; }
        public string Event { get; set; }
        public string Description { get; set; }

    }
}
