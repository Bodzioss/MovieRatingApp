using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace movie_rating_app.Models
{
    public partial class Review
    {
        [DisplayName("Użytkownik")]
        public string UserId { get; set; } = null!;
        [DisplayName("Film")]
        public int MovieId { get; set; }
        [DisplayName("Ocena")]
        public int Rating { get; set; }
        [DisplayName("Opinia")]
        public string? TextReview { get; set; }
        [DisplayName("Czas zarejestrowania opinii")]
        public DateTime? RegisterTimestamp { get; set; }
        public int Id { get; set; }
        [DisplayName("Film")]
        public virtual Movie Movie { get; set; } = null!;
        [DisplayName("Użytkownik")]
        public ApplicationUser User { get; set; } = null!;
    }
}
