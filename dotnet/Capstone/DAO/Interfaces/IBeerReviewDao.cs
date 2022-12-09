using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IBeerReviewDao
    {
        List<BeerReview> GetBeerReviewsByBeerId(int beerId);
        bool AddBeerReview(BeerReview beerReview);
    }
}
