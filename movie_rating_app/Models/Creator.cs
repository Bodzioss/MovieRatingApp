using System;
using System.Collections.Generic;

namespace movie_rating_app.Models
{
    public partial class Creator
    {
        public Creator()
        {
            MovieCreators = new HashSet<MovieCreator>();
        }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? NationalityId { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? CustomRole { get; set; }
        public string? Image { get; set; }

        public virtual Nationality? Nationality { get; set; }
        public virtual ICollection<MovieCreator> MovieCreators { get; set; }
    }
}
