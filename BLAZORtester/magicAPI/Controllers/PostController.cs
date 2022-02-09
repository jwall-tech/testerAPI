using Microsoft.AspNetCore.Mvc;

namespace magicAPI.Controllers
{
    [ApiController]
    [Route("posts")]
    public class PostController : Controller
    {

        [HttpGet(Name = "GetPosts")]
        public IEnumerable<Post> GetPosts()
        {
            return 
        }
    }
}
