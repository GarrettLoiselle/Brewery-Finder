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

        private readonly string sqlGetBrewerys = "SELECT brewery_id, brewery_name,zip_code FROM brewerys; ";
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

                if (reader.Read())
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
        private Brewery GetBreweryFromReader(SqlDataReader reader)
        {
            Brewery b = new Brewery()
            {
                Brewery_ID = Convert.ToInt32(reader["brewery_id"]),
                Brewery_Name = Convert.ToString(reader["brewery_name"]),
                Zip_Code = Convert.ToInt32(reader["zip_code"]),
            };

            return b;
        }
    }
}
