using Microsoft.EntityFrameworkCore;
using test.Models;

namespace test.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base (options) 
        {
            
        }
        public DbSet<customer>customers { get; set; }
        public DbSet<retu> resturent { get; set; }

        public DbSet<LocationMaster> location { get; set; }

        public DbSet<college> colleges { get; set; }
    }
}
