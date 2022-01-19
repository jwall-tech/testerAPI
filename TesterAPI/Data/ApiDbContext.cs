using Microsoft.EntityFrameworkCore;
using TesterAPI.Models;

namespace TesterAPI.Data
{
    public class ApiDbContext : DbContext
    {
        public virtual DbSet<UserData> Users { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {

        }
    }
}