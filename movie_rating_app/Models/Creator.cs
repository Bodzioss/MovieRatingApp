using System;
using System.Collections.Generic;

namespace movie_rating_app.Models
{
    public partial class Creator
    {
        public Creator()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Nationality { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? RoleId { get; set; }
        public string? CustomRole { get; set; }

        public virtual Nationality? NationalityNavigation { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
