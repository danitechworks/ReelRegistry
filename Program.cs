using Microsoft.Data.SqlClient;
using ReelRegistry.Data;
using ReelRegistry.Models;
using ReelRegistry.Repositories;

var movieRepository = new MovieRepository();
var movies = movieRepository.GetAllMovies();

foreach (var movie in movies)
{
    Console.WriteLine($"Title: {movie.Title}, Year: {movie.Year}");
}


