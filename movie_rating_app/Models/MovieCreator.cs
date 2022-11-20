using System;
using System.Collections.Generic;

namespace movie_rating_app.Models
{
    public partial class MovieCreator
    {
        public int MovieId { get; set; }
        public int CreatorId { get; set; }
        public int Id { get; set; }

        public virtual Creator Creator { get; set; } = null!;
        public virtual Movie Movie { get; set; } = null!;
    }
}
