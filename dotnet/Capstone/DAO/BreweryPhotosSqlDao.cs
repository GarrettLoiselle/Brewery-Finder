using Capstone.DAO.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class BreweryPhotosSqlDao : IBreweryPhotosDao
    {
        private readonly string connectionString;

        public BreweryPhotosSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        private readonly string sqlGetPhotosByBreweryId = "SELECT * FROM brewery_photos WHERE brewery_id = @brewery_id;";


        public List<BreweryPhotos> GetPhotosByBreweryId(int breweryId)
        {
            List<BreweryPhotos> photos = new List<BreweryPhotos>();

            try
            {
                using SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlGetPhotosByBreweryId, conn);
                cmd.Parameters.AddWithValue("@brewery_id", breweryId);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    BreweryPhotos onePhoto = GetPhotosFromReader(reader);
                    photos.Add(onePhoto);
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return photos;

        }

        private BreweryPhotos GetPhotosFromReader(SqlDataReader reader)
        {
            BreweryPhotos p = new BreweryPhotos()
            {
                PhotosId = Convert.ToInt32(reader["photos_id"]),
                BreweryId = Convert.ToInt32(reader["brewery_id"]),
                Photo = Convert.ToString(reader["photo"])

            };

            return p;
        }
    }
}
