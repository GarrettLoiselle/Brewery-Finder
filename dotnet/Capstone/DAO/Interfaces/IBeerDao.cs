using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IBeerDao
    {
        List<Beer> GetAllBeers();
        List<Beer> GetBeersByBreweryName(string breweryName);
        bool AddBeer(Beer beer);
        bool UpdateBeer(Beer beer);
        bool DeleteBeer(int beerId);
    }
}
