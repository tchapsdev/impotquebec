using Tchaps.Impotquebec.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tchaps.Impotquebec.Models;
using Microsoft.AspNetCore.Mvc.Filters;

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
        }

        protected AppUser GetCurrentUser()
        {
            if (!string.IsNullOrEmpty(CurrentUser.UserName) || User == null)
                return CurrentUser;
            var login = User.Identity?.Name;
            var user =  _context.Users.FirstOrDefault(u => !string.IsNullOrEmpty(login) && u.NormalizedUserName == login.ToUpper());
            if (user != null)
                CurrentUser = user;
            return CurrentUser;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            GetCurrentUser();
            base.OnActionExecuting(context);    
        }

    }
}
