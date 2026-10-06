using Microsoft.Data.SqlClient;
using ReelRegistry.Data;
using ReelRegistry.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReelRegistry.Repositories
{
    public class GenreRepository
    {
        public List<Genre> GetAllGenres()
        {
            using var connection = new SqlConnection(Database.ConnectionString);
            connection.Open();

            var genres = new List<Genre>();
            string sql = "SELECT Id, Name FROM Genre";

            using var command = new SqlCommand(sql, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var genre = new Genre
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                };
                genres.Add(genre);
            }

            return genres;
        }
    }
}
