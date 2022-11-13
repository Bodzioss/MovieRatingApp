using System.ComponentModel.DataAnnotations;

namespace movie_rating_app.Models
{
    public class MovieModel
    {
        [Key]
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Genre { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public List<ReviewModel> Reviews { get; set; }
        public List<FavouriteModel> Favourites { get; set; }
    }
}
