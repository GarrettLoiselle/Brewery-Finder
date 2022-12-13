using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;

namespace Capstone.DAO
{
    public class UserSqlDao : IUserDao
    {
        private readonly string connectionString;

        private readonly string sqlGetUser = "SELECT user_id, username, password_hash, salt, user_role FROM users " +
            "WHERE username = @username;";

        private readonly string sqlGetUsers = "SELECT user_id, username, password_hash, salt, user_role FROM users; ";

        private readonly string sqlAddUser = "INSERT INTO users (username, password_hash, salt, user_role) " +
            "VALUES(@username, @password_hash, @salt, @user_role)";

        private readonly string sqlGetBreweriesBasedOnUserId = "SELECT brewery_id, brewery_name,brewery_address,brewery_website,brewery_description,brewery_img  FROM breweries JOIN users_in_brewery ON users_in_brewery.user_brewery_id = breweries.brewery_id JOIN users ON users.user_id = users_in_brewery.user_user_id WHERE user_id = @user_id; ";


        public UserSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public User GetUser(string username)
        {
            User returnUser = null;

            try
            {
                using SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlGetUser, conn);
                cmd.Parameters.AddWithValue("@username", username);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    returnUser = GetUserFromReader(reader);
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnUser;
        }

        public List<User> GetUsers()
        {
            List<User> returnUsers = new List<User>();

            try
            {
                using SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlGetUsers, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    User temp = GetUserFromReader(reader);
                    returnUsers.Add(temp);
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnUsers;
        }
        public List<Brewery> GetBreweriesBasedOnUserId(int userId)
        {
            List<Brewery> breweries = new List<Brewery>();

            try
            {
                using SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlGetBreweriesBasedOnUserId, conn);
                cmd.Parameters.AddWithValue("@user_id", userId);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Brewery temp = GetBreweryFromReader(reader);
                    breweries.Add(temp);
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return breweries;
        }

        public User AddUser(string username, string password, string role)
        {
            IPasswordHasher passwordHasher = new PasswordHasher();
            PasswordHash hash = passwordHasher.ComputeHash(password);

            try
            {
                using SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlAddUser, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password_hash", hash.Password);
                cmd.Parameters.AddWithValue("@salt", hash.Salt);
                cmd.Parameters.AddWithValue("@user_role", role);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw;
            }

            return GetUser(username);
        }

        private User GetUserFromReader(SqlDataReader reader)
        {
            User u = new User()
            {
                UserId = Convert.ToInt32(reader["user_id"]),
                Username = Convert.ToString(reader["username"]),
                PasswordHash = Convert.ToString(reader["password_hash"]),
                Salt = Convert.ToString(reader["salt"]),
                Role = Convert.ToString(reader["user_role"]),
            };

            return u;
        }
        private Brewery GetBreweryFromReader(SqlDataReader reader)
        {
            Brewery b = new Brewery()
            {
                BreweryId = Convert.ToInt32(reader["brewery_id"]),
                BreweryName = Convert.ToString(reader["brewery_name"]),
                BreweryAddress = Convert.ToString(reader["brewery_address"]),
                BreweryWebsite = Convert.ToString(reader["brewery_website"]),
                BreweryDescription = Convert.ToString(reader["brewery_description"]),
                BreweryImg = Convert.ToString(reader["brewery_img"]),


            };

            return b;
        }
    }
}
