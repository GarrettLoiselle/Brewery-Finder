using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class BeerReview
    {
        public string ReviewerName { get; set; }
        public int BeerId { get; set; }
        public int BeerReviewId { get; set; }
        public int Rating { get; set; }
        public string ReviewInfo { get; set; }
    }
}
