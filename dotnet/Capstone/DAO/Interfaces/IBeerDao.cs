using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IBeerDao
    {
        List<Beer> GetAllBeers();
        List<Beer> GetBeersByBreweryId(int breweryId);
        decimal AddBeer(Beer beer);
        bool AddBeerConn(decimal beerId, int breweryId);
        bool UpdateBeer(Beer beer);
        bool DeleteBeer(int beerId);
    }
}
