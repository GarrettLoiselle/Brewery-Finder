using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IBreweryDao
    {
        List<Brewery> GetAllBreweries();
        Brewery GetBreweryByID(int breweryID);
        bool AddBrewery(Brewery brewery);
        bool UpdateBrewery(Brewery brewery);
    }
}
