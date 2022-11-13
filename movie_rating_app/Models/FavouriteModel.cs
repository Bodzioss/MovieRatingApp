using System.ComponentModel.DataAnnotations.Schema;

namespace movie_rating_app.Models
{
    [Table("Favourites")]
    public class FavouriteModel
    {
        public int? UserId { get; set; }
        public int? MovieId { get; set; }
     /* public UserModel User { get; set; } */
        public MovieModel MovieModel { get; set; }

    }
}
