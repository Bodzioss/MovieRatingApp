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
        [DisplayName("Film")]
        public virtual Movie Movie { get; set; } = null!;
        [DisplayName("Użytkownik")]
        public ApplicationUser User { get; set; }
    }
}
