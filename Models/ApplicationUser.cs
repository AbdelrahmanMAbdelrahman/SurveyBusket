using Microsoft.AspNetCore.Identity;

namespace SurveyBasket.Models
{
    public sealed class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LasttName { get; set; } = string.Empty;
    }
}
