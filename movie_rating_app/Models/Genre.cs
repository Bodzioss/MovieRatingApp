using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace movie_rating_app.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Movies = new HashSet<Movie>();
        }

        [DisplayName("Gatunek")]
        public string Name { get; set; } = null!;
        public int Id { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
