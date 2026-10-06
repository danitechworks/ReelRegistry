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

            string sql = """
                SELECT m.Id, m.Title, m.ReleaseYear, m.GenreId, g.Name AS GenreName
                FROM Movie AS m
                INNER JOIN Genre AS g ON m.GenreId = g.Id
                """;

            using var command = new SqlCommand(sql, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var movie = new Movie
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    Year = reader.GetInt32(2),
                    GenreId = reader.GetInt32(3),
                    GenreName = reader.GetString(4)
                };

                movies.Add(movie);
            }

            reader.Close();

            return movies;
        }

    }
}
