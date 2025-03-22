using Microsoft.AspNetCore.Identity;

namespace ProgettosettimanaleS6L5.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public string? Telefono { get; set; }
    }
}
