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
        private readonly string sqlGetListBeerByBreweryName = "SELECT beer_id,beer_name,beer_information FROM breweries JOIN beers_in_brewery ON beers_in_brewery.brewery_brewery_id=breweries.brewery_id JOIN beers ON beers.beer_id= beers_in_brewery.brewery_beer_id WHERE brewery_name = @brewery_name; ";
        private readonly string sqlGetAllBeers = "SELECT beer_id,beer_name,beer_information FROM beers ; ";
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
        public List<Beer> GetBeersByBreweryName(string breweryName)
        {
            List<Beer> beers = new List<Beer>();

            try
            {
                using SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlGetListBeerByBreweryName, conn);
                cmd.Parameters.AddWithValue("@brewery_name", breweryName);
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
        private Beer GetBeerFromReader(SqlDataReader reader)
        {
            Beer b = new Beer()
            {
                BeerName = Convert.ToString(reader["beer_name"]),
                BeerId = Convert.ToInt32(reader["beer_id"]),
                BeerInfo = Convert.ToString(reader["beer_information"])

            };

            return b;
        }
    }
}
