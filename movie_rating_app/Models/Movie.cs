using System;
using System.Collections.Generic;

namespace movie_rating_app.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Reviews = new HashSet<Review>();
            Creators = new HashSet<Creator>();
            Users = new HashSet<AspNetUser>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? Length { get; set; }

        public virtual Genre? GenreNavigation { get; set; }
        public virtual MoviesCast IdNavigation { get; set; } = null!;
        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Creator> Creators { get; set; }
        public virtual ICollection<AspNetUser> Users { get; set; }
    }
}
