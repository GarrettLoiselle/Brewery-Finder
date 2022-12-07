﻿using System;
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

        private readonly string sqlGetBreweries = "SELECT brewery_id, brewery_name,brewery_zip,brewery_website FROM breweries; ";
        private readonly string sqlGetListBeerByBreweryName = "SELECT beer_id,beer_name,beer_information FROM breweries JOIN beers_in_brewery ON beers_in_brewery.brewery_brewery_id=breweries.brewery_id JOIN beers ON beers.beer_id= beers_in_brewery.brewery_beer_id WHERE brewery_name = @brewery_name; ";
        private readonly string sqlGetBrewery = "SELECT brewery_id, brewery_name,brewery_zip,brewery_website FROM breweries WHERE brewery_name = @brewery_name; ";
        private readonly string sqlAddBrewery = "INSERT INTO breweries (brewery_name,brewery_zip,brewery_website) VALUES (@brewery_name, @brewery_zip,@brewery_website)";
        private readonly string sqlUpdateBrewery = "UPDATE breweries SET brewery_name=@brewery_name,brewery_zip=@brewery_zip, brewery_website= @brewery_website WHERE brewery_name= @brewery_name";
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
            catch (SqlException ex)
            {
                throw;
            }

            return breweries;
        }
        public Brewery GetBreweryByName(string breweryName)
        {
            Brewery brewery = new Brewery();

            try
            {
                using SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlGetBrewery, conn);
                cmd.Parameters.AddWithValue("@brewery_name", breweryName);
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
                    cmd.Parameters.AddWithValue("@brewery_website", brewery.BreweryWebsite);
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
                    cmd.Parameters.AddWithValue("@brewery_website", brewery.BreweryWebsite);
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
        private Brewery GetBreweryFromReader(SqlDataReader reader)
        {
            Brewery b = new Brewery()
            {
                BreweryId = Convert.ToInt32(reader["brewery_id"]),
                BreweryName = Convert.ToString(reader["brewery_name"]),
                ZipCode = Convert.ToInt32(reader["brewery_zip"]),
                BreweryWebsite = Convert.ToString(reader["brewery_website"]),
            };

            return b;
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
