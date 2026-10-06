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
        public async Task<List<Genre>> GetAllGenresAsync()
        {
            using var connection = new SqlConnection(Database.ConnectionString);
            await connection.OpenAsync();

            var genres = new List<Genre>();
            string sql = "SELECT Id, Name FROM Genre";

            using var command = new SqlCommand(sql, connection);
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
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
