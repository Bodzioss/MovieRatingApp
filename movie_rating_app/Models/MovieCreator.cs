using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace movie_rating_app.Models
{
    public partial class MovieCreator
    {
        public int Id { get; set; }
        [DisplayName("Film")]
        public int MovieId { get; set; }
        [DisplayName("Osoba")]
        public int CreatorId { get; set; }
        [DisplayName("Rola")]
        public int RoleId { get; set; }

        public virtual Creator? Creator { get; set; } = null!;
        public virtual Movie? Movie { get; set; } = null!;
        public virtual Role? Role { get; set; } = null!;
    }
}
