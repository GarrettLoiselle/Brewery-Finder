using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IBreweryDao
    {
        List<Brewery> GetAllBrewerys();
    }
}
