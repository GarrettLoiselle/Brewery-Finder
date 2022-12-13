using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IBreweryDao
    {
        List<Brewery> GetAllBreweries();
        Brewery GetBreweryById(int breweryId);
        int AddBrewery(Brewery brewery);
        bool UpdateBrewery(Brewery brewery);
        bool AddBreweryConn(string brewerUsername, int breweryId);
    }
}
