using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace movie_rating_app.Models
{
    public partial class Actor
    {
        public Actor()
        {
            MoviesCasts = new HashSet<MoviesCast>();
        }

        public int Id { get; set; }
        [DisplayName("Imię")]
        public string? FirstName { get; set; }
        [DisplayName("Nazwisko")]
        public string? LastName { get; set; }
        [DisplayName("Kraj pochodzenia")]
        public int? NationalityId { get; set; }
        [DisplayName("Rola")]
        public string? RoleName { get; set; }
        [DisplayName("Data urodzenia")]
        public DateTime? BirthDate { get; set; }
        [DisplayName("Ścieżka do zdjęcia")]
        public string? Image { get; set; }

        public virtual Nationality? Nationality { get; set; }
        public virtual ICollection<MoviesCast> MoviesCasts { get; set; }
    }
}
