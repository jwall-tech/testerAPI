using Microsoft.AspNetCore.Identity;

namespace magicAPI
{
    public class Post : IdentityUser
    {
        public string Content { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }
    }
}
