using System;
using System.Collections.Generic;

namespace movie_rating_app.Models
{
    public partial class MoviesCast
    {
        public int MovieId { get; set; }
        public int ActorId { get; set; }
        public int Id { get; set; }

        public virtual Actor Actor { get; set; } = null!;
        public virtual Movie? Movie { get; set; }
    }
}
