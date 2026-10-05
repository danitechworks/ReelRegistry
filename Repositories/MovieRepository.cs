using Microsoft.Data.SqlClient;
using ReelRegistry.Data;
using ReelRegistry.Models;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace ReelRegistry.Repositories
{
    public class MovieRepository
    {
        public List<Movie> GetAllMovies()
        {
            using var connection = new SqlConnection(Database.ConnectionString);
            connection.Open();

            var movies = new List<Movie>();

            string sql = "SELECT Id, Title, ReleaseYear, GenreId FROM Movie";

            using var command = new SqlCommand(sql, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var movie = new Movie
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    Year = reader.GetInt32(2),
                    GenreId = reader.GetInt32(3)
                };

                movies.Add(movie);
            }

            return movies;
        }

    }
}
