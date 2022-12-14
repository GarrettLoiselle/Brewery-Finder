using Capstone.DAO.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class BreweryNewsSqlDao : IBreweryNewsDao
    {
        private readonly string connectionString;

        public BreweryNewsSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        private readonly string sqlGetNewsByBreweryId = "SELECT * FROM brewery_news WHERE brewery_id = @brewery_id;";

        public List<BreweryNews> GetNewsByBreweryId(int breweryId)
        {
            List<BreweryNews> news = new List<BreweryNews>();

            try
            {
                using SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlGetNewsByBreweryId, conn);
                cmd.Parameters.AddWithValue("@brewery_id", breweryId);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    BreweryNews oneNews = GetNewsFromReader(reader);
                    news.Add(oneNews);
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return news;


        }

        private BreweryNews GetNewsFromReader(SqlDataReader reader)
        {
            BreweryNews m = new BreweryNews()
            {
                NewsId = Convert.ToInt32(reader["news_id"]),
                BreweryId = Convert.ToInt32(reader["brewery_id"]),
                News = Convert.ToString(reader["news"])

            };

            return m;
        }
    }
}
