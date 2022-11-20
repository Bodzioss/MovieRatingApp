using Microsoft.AspNetCore.Identity;

namespace movie_rating_app.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public int? NationalityId { get; set; }

    }
}