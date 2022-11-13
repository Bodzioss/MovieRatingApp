namespace movie_rating_app.Models
{
    public class ReviewModel
    {
        public int? UserId { get; set; }
        public int? MovieId { get; set; }
        public int Rating { get; set; }
        public string? TextReview { get; set; }
        public DateTime? RegisterTimestamp { get; set; }

     /* public UserModel User { get; set; } */
        public MovieModel Movie { get; set; }
    }
}
