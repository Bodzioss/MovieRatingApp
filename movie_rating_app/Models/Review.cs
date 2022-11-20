using System;
using System.Collections.Generic;

namespace movie_rating_app.Models
{
    public partial class Review
    {
        public string UserId { get; set; } = null!;
        public int MovieId { get; set; }
        public int Rating { get; set; }
        public string? TextReview { get; set; }
        public DateTime? RegisterTimestamp { get; set; }
        public int Id { get; set; }

        public virtual Movie Movie { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;
    }
}
