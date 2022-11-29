using System;
using System.Collections.Generic;

namespace movie_rating_app.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Favourites = new HashSet<Favourite>();
            MovieCreators = new HashSet<MovieCreator>();
            Reviews = new HashSet<Review>();
            MoviesCast = new HashSet<MoviesCast>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public int? GenreId { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? Length { get; set; }
        public string? Image { get; set; }

        public virtual Genre? Genre { get; set; }
        public virtual ICollection<MoviesCast> MoviesCast { get; set; }
        public virtual ICollection<Favourite> Favourites { get; set; }
        public virtual ICollection<MovieCreator> MovieCreators { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
