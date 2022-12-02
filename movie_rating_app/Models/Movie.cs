using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        [DisplayName("Opis")]
        public string? Description { get; set; }
        [DisplayName("Gatunek")]
        public int? GenreId { get; set; }
        [DisplayName("Język")]
        public int? NationalityId { get; set; }
        [DisplayName("Data wydania")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ReleaseDate { get; set; }
        [DisplayName("Długość filmu")]
        public int? Length { get; set; }
        [DisplayName("Ścieżka do zdjęcia")]
        public string? Image { get; set; }
        [DisplayName("Gatunek")]
        public virtual Genre? Genre { get; set; }
        [DisplayName("Język")]
        public virtual Nationality? Nationality { get; set; }
        public virtual ICollection<MoviesCast> MoviesCast { get; set; }
        public virtual ICollection<Favourite> Favourites { get; set; }
        public virtual ICollection<MovieCreator> MovieCreators { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
