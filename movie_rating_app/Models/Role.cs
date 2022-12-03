using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace movie_rating_app.Models
{
    public partial class Role
    {
        public Role()
        {
            MoviePeople = new HashSet<MoviePerson>();
        }

        public int Id { get; set; }
        [DisplayName("Rola")]
        public string Name { get; set; } = null!;

        public virtual ICollection<MoviePerson> MoviePeople { get; set; }
    }
}
