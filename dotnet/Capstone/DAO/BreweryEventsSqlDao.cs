using Capstone.DAO.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class BreweryEventsSqlDao:IBreweryEventsDao
    {
         
    
        private readonly string connectionString;

        private readonly string sqlGetEventsByBreweryId = "SELECT event, description FROM brewery_events WHERE brewery_id = @brewery_id;";

       
        public BreweryEventsSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<BreweryEvents> GetEventsByBreweryId(int breweryId)
        {
            List<BreweryEvents> events = new List<BreweryEvents>();

            try
            {
                using SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlGetEventsByBreweryId, conn);
                cmd.Parameters.AddWithValue("@brewery_id", breweryId);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    BreweryEvents oneEvent = GetEventFromReader(reader);
                    events.Add(oneEvent);
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return events;
        }

        private BreweryEvents GetEventFromReader(SqlDataReader reader)
        {
            BreweryEvents be = new BreweryEvents()
            {
                EventId = Convert.ToInt32(reader["event_id"]),
                BreweryId = Convert.ToInt32(reader["brewery_id"]),
                Event = Convert.ToString(reader["event"]),
                Description = Convert.ToString(reader["description"])

            };

            return be;
        }
    }
}
