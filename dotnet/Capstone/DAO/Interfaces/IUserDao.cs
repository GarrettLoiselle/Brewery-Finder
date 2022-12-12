using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IUserDao
    {
        User GetUser(string username);
        List<User> GetUsers();
        User AddUser(string username, string password, string role);
        List<Brewery> GetBreweriesBasedOnUserId(int userId);
    }
}
