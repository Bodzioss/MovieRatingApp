using System.ComponentModel;

namespace movie_rating_app.Models
{
    public partial class Creator
    {
        public Creator()
        {
            MovieCreators = new HashSet<MovieCreator>();
        }

        public int Id { get; set; }
        [DisplayName("Imię")]
        public string? FirstName { get; set; }
        [DisplayName("Nazwisko")]
        public string? LastName { get; set; }
        [DisplayName("Imię i nazwisko")]
        public string? PersonName { get; set; }
        [DisplayName("Kraj pochodzenia")]
        public int? NationalityId { get; set; }
        [DisplayName("Data urodzenia")]
        public DateTime? BirthDate { get; set; }
        [DisplayName("Rola")]
        public string? Image { get; set; }
        [DisplayName("Kraj pochodzenia")]
        public virtual Nationality? Nationality { get; set; }
        public virtual ICollection<MovieCreator> MovieCreators { get; set; }
    }
}
