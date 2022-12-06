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
        private readonly string sqlAddNewBrewery = "INSERT INTO brewerys (brewery_name,brewery_zip) VALUES (@brewery_name, @brewery_zip)";
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
        public bool AddBrewery(Brewery brewery)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlAddNewBrewery, conn);
                    cmd.Parameters.AddWithValue("@brewery_name", brewery.Brewery_Name);
                    cmd.Parameters.AddWithValue("@brewery_zip", brewery.Zip_Code);
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
        private Brewery GetBreweryFromReader(SqlDataReader reader)
        {
            Brewery b = new Brewery()
            {
                Brewery_ID = Convert.ToInt32(reader["brewery_id"]),
                Brewery_Name = Convert.ToString(reader["brewery_name"]),
                Zip_Code = Convert.ToInt32(reader["brewery_zip"]),
            };

            return b;
        }
    }
}
