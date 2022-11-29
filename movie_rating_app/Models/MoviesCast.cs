using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace movie_rating_app.Models
{
    public partial class MoviesCast
    {
        public int Id { get; set; }
        [DisplayName("Film")]
        public int MovieId { get; set; }
        [DisplayName("Aktor")]
        public int ActorId { get; set; }
        [DisplayName("Rola")]
        public int RoleId { get; set; }
        [DisplayName("Aktor")]
        public virtual Actor? Actor { get; set; } = null!;
        [DisplayName("Film")]
        public virtual Movie? Movie { get; set; } = null!;
        [DisplayName("Rola")]
        public virtual Role? Role { get; set; } = null!;
    }
}
