using System;
using System.Collections.Generic;
using System.ComponentModel;

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
        [DisplayName("Tytuł")]
        public string? Title { get; set; }
        [DisplayName("Gatunek")]
        public int? GenreId { get; set; }
        [DisplayName("Data wydania")]
        public DateTime? ReleaseDate { get; set; }
        [DisplayName("Długość filmu")]
        public int? Length { get; set; }
        [DisplayName("Ścieżka do zdjęcia")]
        public string? Image { get; set; }

        public virtual Genre? Genre { get; set; }
        public virtual ICollection<MoviesCast> MoviesCast { get; set; }
        public virtual ICollection<Favourite> Favourites { get; set; }
        public virtual ICollection<MovieCreator> MovieCreators { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
