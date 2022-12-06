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

        private readonly string sqlGetBrewerys = "SELECT brewery_id, brewery_name,brewery_zip FROM brewerys; ";
        private readonly string sqlGetBrewery = "SELECT brewery_id, brewery_name,brewery_zip FROM brewerys WHERE brewery_id = @brewery_id; ";
        private readonly string sqlAddBrewery = "INSERT INTO brewerys (brewery_name,brewery_zip) VALUES (@brewery_name, @brewery_zip)";
        private readonly string sqlUpdateBrewery = "UPDATE brewerys SET brewery_name=@brewery_name,brewery_zip=@brewery_zip WHERE brewery_id= @brewery_id";
        public BrewerySqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public List<Brewery> GetAllBrewerys()
        {
            List<Brewery> breweries = new List<Brewery>();

            try
            {
                using SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlGetBrewerys, conn);
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
        public Brewery GetBreweryByID(int breweryID)
        {
            Brewery brewery = new Brewery();

            try
            {
                using SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlGetBrewery, conn);
                cmd.Parameters.AddWithValue("@brewery_id", breweryID);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    
                    brewery = GetBreweryFromReader(reader);
                   
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return brewery;
        }
        public bool AddBrewery(Brewery brewery)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlAddBrewery, conn);
                    cmd.Parameters.AddWithValue("@brewery_name", brewery.BreweryName);
                    cmd.Parameters.AddWithValue("@brewery_zip", brewery.ZipCode);
                    int count = cmd.ExecuteNonQuery();

                    if(count >0)
                    { result = true; }
                }
            }
            catch(Exception ex)
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
                    cmd.Parameters.AddWithValue("@brewery_zip", brewery.ZipCode);
                    cmd.Parameters.AddWithValue("@brewery_id", brewery.BreweryId);
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
                ZipCode = Convert.ToInt32(reader["brewery_zip"]),
            };

            return b;
        }
    }
}
