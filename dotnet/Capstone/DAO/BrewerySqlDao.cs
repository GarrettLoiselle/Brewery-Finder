using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;

namespace Capstone.DAO
{
    public class BrewerySqlDao:IBreweryDao
    {
        private readonly string connectionString;

        private readonly string sqlGetBreweries = "SELECT brewery_id, brewery_name,brewery_address,brewery_website,brewery_description,brewery_img  FROM breweries; ";
        private readonly string sqlGetBrewery = "SELECT brewery_id, brewery_name,brewery_address,brewery_website,brewery_description,brewery_img  FROM breweries WHERE brewery_id = @brewery_id; ";
        private readonly string sqlAddBrewery = "INSERT INTO breweries (brewery_name,brewery_address,brewery_website,brewery_description,brewery_img ) VALUES (@brewery_name, @brewery_address,@brewery_website,@brewery_description,@brewery_img ); SELECT @@IDENTITY;";
        private readonly string sqlAddBreweryConn = "INSERT INTO [users_in_brewery](user_user_id,user_brewery_id)VALUES((select user_id from  users where username = @username),(select brewery_id from breweries where brewery_id = @brewery_id)); INSERT INTO [users_in_brewery](user_user_id,user_brewery_id)VALUES((select user_id from  users where user_role = 'admin'),(select brewery_id from breweries where brewery_id = @brewery_id));";
        private readonly string sqlUpdateBrewery = "UPDATE breweries SET brewery_name=@brewery_name,brewery_address=@brewery_address, brewery_website= @brewery_website,brewery_description=@brewery_description,brewery_img =@brewery_img  WHERE brewery_id= @brewery_id";
        public BrewerySqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public List<Brewery> GetAllBreweries()
        {
            List<Brewery> breweries = new List<Brewery>();

            try
            {
                using SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlGetBreweries, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Brewery brewery = new Brewery();
                    brewery = GetBreweryFromReader(reader);
                    breweries.Add(brewery);
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return breweries;
        }
        public Brewery GetBreweryById(int breweryId)
        {
            Brewery brewery = new Brewery();

            try
            {
                using SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlGetBrewery, conn);
                cmd.Parameters.AddWithValue("@brewery_id", breweryId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    
                    brewery = GetBreweryFromReader(reader);
                   
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return brewery;
        }
        public int AddBrewery(Brewery brewery)
        {
            decimal result = 0;
            int actualResult = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlAddBrewery, conn);
                    cmd.Parameters.AddWithValue("@brewery_name", brewery.BreweryName);
                    cmd.Parameters.AddWithValue("@brewery_address", brewery.BreweryAddress);
                    cmd.Parameters.AddWithValue("@brewery_website", brewery.BreweryWebsite);
                    cmd.Parameters.AddWithValue("@brewery_description", brewery.BreweryDescription); 
                    cmd.Parameters.AddWithValue("@brewery_img", brewery.BreweryImg);
                    result = (decimal)cmd.ExecuteScalar();

                }
            }
            catch(Exception ex)
            {
               
            }
            actualResult = (int)result;
            return actualResult;
        }
        public bool AddBreweryConn(string brewerUsername,int breweryId)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlAddBreweryConn, conn);
                    cmd.Parameters.AddWithValue("@brewery_id", breweryId);
                    cmd.Parameters.AddWithValue("@username", brewerUsername);
                    int count = cmd.ExecuteNonQuery();

                    if (count > 0)
                    { result = true; }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
        public bool UpdateBrewery(Brewery brewery)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlUpdateBrewery, conn);
                    cmd.Parameters.AddWithValue("@brewery_name", brewery.BreweryName);
                    cmd.Parameters.AddWithValue("@brewery_address", brewery.BreweryAddress);
                    cmd.Parameters.AddWithValue("@brewery_id", brewery.BreweryId);
                    cmd.Parameters.AddWithValue("@brewery_website", brewery.BreweryWebsite); 
                    cmd.Parameters.AddWithValue("@brewery_description", brewery.BreweryDescription);
                    cmd.Parameters.AddWithValue("@brewery_img", brewery.BreweryImg);
                    int count = cmd.ExecuteNonQuery();

                    if (count > 0)
                    { result = true; }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
        private Brewery GetBreweryFromReader(SqlDataReader reader)
        {
            Brewery b = new Brewery()
            {
                BreweryId = Convert.ToInt32(reader["brewery_id"]),
                BreweryName = Convert.ToString(reader["brewery_name"]),
                BreweryAddress = Convert.ToString(reader["brewery_address"]),
                BreweryWebsite = Convert.ToString(reader["brewery_website"]),
                BreweryDescription= Convert.ToString(reader["brewery_description"]),
                BreweryImg= Convert.ToString(reader["brewery_img"]),
                

            };

            return b;
        }
    }
}
