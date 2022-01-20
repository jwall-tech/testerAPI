using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TesterAPI.Controllers
{
    public class HomeController
    {
        [Authorize(Roles = "Everyone")]
        public IActionResult Everyone()
        {
            return View();
        }

        private IActionResult View()
        {
            throw new NotImplementedException();
        }
    }
}
