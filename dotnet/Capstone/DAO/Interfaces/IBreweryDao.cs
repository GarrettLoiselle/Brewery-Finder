using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IBreweryDao
    {
        List<Brewery> GetAllBreweries();
        Brewery GetBreweryByName(string breweryName);
        bool AddBrewery(Brewery brewery);
        bool UpdateBrewery(Brewery brewery);
    }
}
