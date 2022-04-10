using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FleaMarket.Controllers
{
    public abstract class ExtendedController : Controller
    {
        protected readonly UserManager<IdentityUser> UserManager;

        protected ExtendedController(UserManager<IdentityUser> userManager) => UserManager = userManager;

        protected Task<IdentityUser> GetCurrentUser() => UserManager.GetUserAsync(HttpContext.User);
    }
}