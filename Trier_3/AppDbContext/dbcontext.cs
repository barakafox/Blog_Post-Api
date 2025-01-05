using Microsoft.EntityFrameworkCore;
using Trier_3.Models;

namespace Trier_3.AppDbContext
{
    public class dbcontext : DbContext
    {
        public dbcontext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Reaction> Reactions { get; set; }  
        public DbSet<BlogPost> Blogs { get; set; }
    }
}
