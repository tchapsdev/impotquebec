using Tchaps.Impotquebec.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tchaps.Impotquebec.Models;

namespace Tchaps.Impotquebec.Controllers
{
    //[Authorize]
    public class SecureBaseController : Controller
    {
        protected AppUser CurrentUser = new();

        protected readonly ApplicationDbContext _context;
        public SecureBaseController(ApplicationDbContext context)
        {
            _context = context;
            if (User != null)
                CurrentUser = GetUser(User.Identity.Name);
        }

        protected AppUser GetUser(string userName)
        {
            return _context.Users.FirstOrDefault(u => u.NormalizedUserName == userName.ToUpper());
        }
       
    }
}
