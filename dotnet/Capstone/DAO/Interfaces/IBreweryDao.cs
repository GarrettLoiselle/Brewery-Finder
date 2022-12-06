using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IBreweryDao
    {
        List<Brewery> GetAllBrewerys();
        Brewery GetBreweryByID(int breweryID);
        bool AddBrewery(Brewery brewery);
        bool UpdateBrewery(Brewery brewery);
    }
}
