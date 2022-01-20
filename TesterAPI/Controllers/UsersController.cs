using TesterAPI.Modules;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;

namespace TesterAPI.Controllers
{
    public class UsersController : BController
    {
        public IActionResult Login(HttpContext httpContext)
        {
            if (!httpContext.User.Identity.IsAuthenticated)
            {
                return Challenge(OpenIdConnectDefaults.AuthenticationScheme);
            }
            return RedirectToAction("Index", "Home");
        }

        private IActionResult RedirectToAction(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        private IActionResult Challenge(string authenticationScheme)
        {
            throw new NotImplementedException();
        }

        public IActionResult Logout()
        {
            return new SignOutResult(new[]
            {
        OpenIdConnectDefaults.AuthenticationScheme,
        CookieAuthenticationDefaults.AuthenticationScheme
      });
        }
    }
}
