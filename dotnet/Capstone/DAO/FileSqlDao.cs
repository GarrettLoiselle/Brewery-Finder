using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class FileSqlDao:IFileDao
    {
        private readonly string connectionString;

        private string sqlAddFile = "INSERT INTO brewery_files(brewery_id, file_name, file_content) VALUES (@brewery_id, @file_name, @file_content);";
        private string sqlGetFilesBasedOnBreweryId = "SELECT file_id, brewery_id, file_name, file_content FROM brewery_files WHERE brewery_id=@brewery_id;";
        public FileSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public List<File> GetFilesBasedOnBreweryId(int breweryId)
        {
            List<File> files = new List<File>();

            try
            {
                using SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlGetFilesBasedOnBreweryId, conn);
                cmd.Parameters.AddWithValue("@brewery_id", breweryId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    File file = GetFileFromReader(reader);
                    files.Add(file);

                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return files;
        }
        public bool AddFile(File file)
        {
           bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlAddFile, conn);
                    cmd.Parameters.AddWithValue("@brewery_id", file.BreweryId);
                    cmd.Parameters.AddWithValue("@file_name", file.FileName);
                    cmd.Parameters.AddWithValue("@file_content", file.Content);
                    int total = cmd.ExecuteNonQuery();

                    if (total > 0)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }
        private File GetFileFromReader(SqlDataReader reader)
        {
            File f = new File()
            {
                FileId = Convert.ToInt32(reader["file_id"]),
                BreweryId = Convert.ToInt32(reader["brewery_id"]),
                FileName = Convert.ToString(reader["file_name "]),
                Content = (byte[])(reader["file_content"]),

            };
            return f;
        }
    }
}
