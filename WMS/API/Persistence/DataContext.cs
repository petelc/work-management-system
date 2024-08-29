using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        //public DbSet<Roles> Roles { get; set; }

        public DbSet<Requests> Requests { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Change> Changes { get; set; }
        public DbSet<Category> Categories { get; set; }



    }
}