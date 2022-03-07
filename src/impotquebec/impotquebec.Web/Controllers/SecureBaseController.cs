using Tchaps.Impotquebec.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Tchaps.Impotquebec.Controllers
{
    //[Authorize]
    public class SecureBaseController : Controller
    {
        protected IdentityUser CurrentUser = new();

        protected readonly ApplicationDbContext _context;
        public SecureBaseController(ApplicationDbContext context)
        {
            _context = context;
            if (User != null)
                CurrentUser = GetUser(User.Identity.Name);
        }

        protected IdentityUser GetUser(string userName)
        {
            return _context.Users.FirstOrDefault(u => u.NormalizedUserName == userName.ToUpper());
        }
       
    }
}
