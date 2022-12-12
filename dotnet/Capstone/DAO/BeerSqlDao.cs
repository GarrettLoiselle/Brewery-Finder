using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;


namespace Capstone.DAO
{
    public class BeerSqlDao:IBeerDao
    {
        private readonly string connectionString;

        public BeerSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        private readonly string sqlGetListBeerByBreweryId = "SELECT beer_id,beer_name,beer_information,beer_img FROM breweries JOIN beers_in_brewery ON beers_in_brewery.brewery_brewery_id=breweries.brewery_id JOIN beers ON beers.beer_id= beers_in_brewery.brewery_beer_id WHERE brewery_id = @brewery_id; ";
        private readonly string sqlGetAllBeers = "SELECT brewery_id, beer_id,beer_name,beer_information,beer_img FROM beers JOIN beers_in_brewery ON beers_in_brewery.brewery_beer_id=beers.beer_id JOIN breweries ON breweries.brewery_id= beers_in_brewery.brewery_brewery_id; ";
        private readonly string sqlAddBeer = "INSERT INTO beers (beer_name,beer_information,beer_img) VALUES (@beer_name, @beer_information,@beer_img);SELECT @@IDENTITY;";
        private readonly string sqlAddBeerConn = "INSERT INTO [beers_in_brewery](brewery_beer_id,brewery_brewery_id)VALUES((select beer_id from  beers where beer_id = @beer_id),(select brewery_id from breweries where brewery_id = @brewery_id));";
        private readonly string sqlUpdateBeer = "UPDATE beers SET beer_name=@beer_name,beer_information=@beer_information, beer_img= @beer_img WHERE beer_id= @beer_id";
        private readonly string sqlDeleteBeer = "DELETE FROM beers WHERE beer_id=@beer_id";
        public List<Beer> GetAllBeers()
        {
            List<Beer> beers = new List<Beer>();

            try
            {
                using SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlGetAllBeers, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    Beer beer = GetBeerExtraFromReader(reader);
                    beers.Add(beer);
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return beers;
        }
        public List<Beer> GetBeersByBreweryId(int breweryId)
        {
            List<Beer> beers = new List<Beer>();

            try
            {
                using SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlGetListBeerByBreweryId, conn);
                cmd.Parameters.AddWithValue("@brewery_id", breweryId);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    Beer beer = GetBeerFromReader(reader);
                    beers.Add(beer);
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return beers;
        }
        public int AddBeer(Beer beer)
        {
            int result = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlAddBeer, conn);
                    cmd.Parameters.AddWithValue("@beer_name", beer.BeerName);
                    cmd.Parameters.AddWithValue("@beer_information", beer.BeerInfo);
                    cmd.Parameters.AddWithValue("@beer_img", beer.BeerImg);
                    result = (int)cmd.ExecuteScalar();

                }
            }
            catch (Exception ex)
            {
               
            }
            return result;
        }
        public bool AddBeerConn(int beerId,int breweryId)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlAddBeerConn, conn);
                    
                    cmd.Parameters.AddWithValue("@beer_id", beerId);
                    cmd.Parameters.AddWithValue("@brewery_id", breweryId);
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
        public bool UpdateBeer(Beer beer)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlUpdateBeer, conn);
                    cmd.Parameters.AddWithValue("@beer_id", beer.BeerId);
                    cmd.Parameters.AddWithValue("@beer_name", beer.BeerName);
                    cmd.Parameters.AddWithValue("@beer_information", beer.BeerInfo);
                    cmd.Parameters.AddWithValue("@beer_img", beer.BeerImg);
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
        public bool DeleteBeer(int beerId)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlDeleteBeer, conn);
                    cmd.Parameters.AddWithValue("@beer_id", beerId);
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
        private Beer GetBeerFromReader(SqlDataReader reader)
        {
            Beer b = new Beer()
            {
                BeerName = Convert.ToString(reader["beer_name"]),
                BeerId = Convert.ToInt32(reader["beer_id"]),
                BeerInfo = Convert.ToString(reader["beer_information"]),
                BeerImg = Convert.ToString(reader["beer_img"])

            };

            return b;
        }
        private Beer GetBeerExtraFromReader(SqlDataReader reader)
        {
            Beer b = new Beer()
            {
                BeerName = Convert.ToString(reader["beer_name"]),
                BeerId = Convert.ToInt32(reader["beer_id"]),
                BreweryId = Convert.ToInt32(reader["brewery_id"]),
                BeerInfo = Convert.ToString(reader["beer_information"]),
                BeerImg = Convert.ToString(reader["beer_img"])

            };

            return b;
        }
    }
}
