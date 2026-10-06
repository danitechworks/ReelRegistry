using System;
using System.Collections.Generic;
using System.Text;

namespace ReelRegistry.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int GenreId { get; set; }

        public string GenreName { get; set; } = string.Empty;
    }
}
