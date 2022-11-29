using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace movie_rating_app.Models
{
    public partial class Role
    {
        public Role()
        {
            MovieCreators = new HashSet<MovieCreator>();
            MoviesCasts = new HashSet<MoviesCast>();
        }

        public int Id { get; set; }
        [DisplayName("Rola")]
        public string Name { get; set; } = null!;

        public virtual ICollection<MovieCreator> MovieCreators { get; set; }
        public virtual ICollection<MoviesCast> MoviesCasts { get; set; }
    }
}
