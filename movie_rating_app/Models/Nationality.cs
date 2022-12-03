using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace movie_rating_app.Models
{
    public partial class Nationality
    {
        public Nationality()
        {
            People = new HashSet<Person>();
        }

        [DisplayName("Kraj")]
        public string Name { get; set; } = null!;
        public int Id { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}
