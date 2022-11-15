using System;
using System.Collections.Generic;

namespace movie_rating_app.Models
{
    public partial class Actor
    {
        public Actor()
        {
            MoviesCasts = new HashSet<MoviesCast>();
        }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Nationality { get; set; }
        public string? RoleName { get; set; }
        public DateTime? BirthDate { get; set; }

        public virtual Nationality? NationalityNavigation { get; set; }
        public virtual ICollection<MoviesCast> MoviesCasts { get; set; }
    }
}
