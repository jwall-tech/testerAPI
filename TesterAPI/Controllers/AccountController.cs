using Okta.AspNet;
using Microsoft.Owin.Host.SystemWeb;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;

public class AccountController : Controller
{
    public ActionResult Login()
    {
        if (!HttpContext.User.Identity.IsAuthenticated)
        {
            HttpContext.GetOwinContext().Authentication.Challenge(
                OktaDefaults.MvcAuthenticationType);
            return new HttpUnauthorizedResult();
        }

        return RedirectToAction("Index", "Home");
    }
}