using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace movie_rating_app.Models
{
    public partial class MoviePerson
    {
        public int Id { get; set; }
        [DisplayName("Film")]
        public int MovieId { get; set; }
        [DisplayName("Osoba")]
        public int PersonId { get; set; }
        [DisplayName("Rola")]
        public int RoleId { get; set; }
        [DisplayName("Osoba")]
        public virtual Person? Person { get; set; } = null!;
        [DisplayName("Film")]
        public virtual Movie? Movie { get; set; } = null!;
        [DisplayName("Rola")]
        public virtual Role? Role { get; set; } = null!;
    }
}
