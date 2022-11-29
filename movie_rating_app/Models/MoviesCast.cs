using System;
using System.Collections.Generic;

namespace movie_rating_app.Models
{
    public partial class MoviesCast
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int ActorId { get; set; }
        public int RoleId { get; set; }

        public virtual Actor? Actor { get; set; } = null!;
        public virtual Movie? Movie { get; set; } = null!;
        public virtual Role? Role { get; set; } = null!;
    }
}
