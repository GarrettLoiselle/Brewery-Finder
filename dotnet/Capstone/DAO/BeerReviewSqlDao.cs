using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class BeerReviewSqlDao:IBeerReviewDao

    {
        private readonly string connectionString;

        public BeerReviewSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        private readonly string sqlGetListBeerReviewByBeerId = "SELECT beer_review_id,beer_id,reviewer_name,rating,review_information FROM beers JOIN beers ON beers.beer_id=beer_reviews.beer_id WHERE beer_id = @beer_id; ";
        private readonly string sqlAddBeerReview = "INSERT INTO beer_reviews (beer_id,reviewer_name,rating,review_information) VALUES (@beer_id, @reviewer_name,@rating,@review_information);";
        public List<BeerReview> GetBeerReviewsByBeerId(int beerId)
        {
            List<BeerReview> beerReviews = new List<BeerReview>();

            try
            {
                using SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlGetListBeerReviewByBeerId, conn);
                cmd.Parameters.AddWithValue("@beer_id", beerId);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    BeerReview beerReview = GetBeerReviewFromReader(reader);
                    beerReviews.Add(beerReview);
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return beerReviews;
        }
        public bool AddBeerReview(BeerReview beerReview)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlAddBeerReview, conn);
                    cmd.Parameters.AddWithValue("@beer_id", beerReview.BeerId);
                    cmd.Parameters.AddWithValue("@reviewer_name", beerReview.ReviewerName);
                    cmd.Parameters.AddWithValue("@rating", beerReview.Rating);
                    cmd.Parameters.AddWithValue("@review_information", beerReview.ReviewInfo);
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
        private BeerReview GetBeerReviewFromReader(SqlDataReader reader)
        {
            BeerReview br = new BeerReview()
            {
                ReviewerName = Convert.ToString(reader["reviewer_name"]),
                BeerId = Convert.ToInt32(reader["beer_id"]),
                ReviewInfo = Convert.ToString(reader["review_information"]),
                BeerReviewId = Convert.ToInt32(reader["beer_review_id"]),
                Rating= Convert.ToInt32(reader["rating"]),

            };

            return br;
        }
    }
}
