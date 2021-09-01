using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Contexts
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options):base(options)
        {
            
        }

        public DbSet<History> History { get; set; }
    }
}