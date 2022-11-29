using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace movie_rating_app.Models
{
    public partial class Favourite
    {
        [DisplayName("Użytkownik")]
        public string UserId { get; set; } = null!;
        [DisplayName("Film")]
        public int MovieId { get; set; }
        public int Id { get; set; }

        public virtual Movie Movie { get; set; } = null!;
        public ApplicationUser User { get; set; }
    }
}
