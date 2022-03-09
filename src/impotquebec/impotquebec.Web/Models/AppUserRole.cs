using Microsoft.AspNetCore.Identity;

namespace Tchaps.Impotquebec.Models
{
    public class AppUserRole: IdentityRole<Guid>
    {
        public string? Description { get; set; }    
    }
}
