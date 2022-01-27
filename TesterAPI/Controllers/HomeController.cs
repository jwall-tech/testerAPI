using Microsoft.AspNetCore.Mvc;

namespace TesterAPI.Controllers
{
    [Route("")]

    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet("privacy")]
        public ActionResult Privacy()
        {
            return View("Privacy");
        }
    }
}
