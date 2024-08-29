using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        //public DbSet<Roles> Roles { get; set; }

        public DbSet<Requests> Requests { get; set; }
        public DbSet<Requestor> Requestors { get; set; }
        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectManager> ProjectManagers { get; set; }

        public DbSet<Change> Changes { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Work> Works { get; set; }
        public DbSet<WorkItem> WorkItems { get; set; }
        public DbSet<Icon> Icons { get; set; }

        // NOTE: Do I need to make a Requestors table to link appuser to Requests?
        // NOTE: Also then to I need to create a table for PM, CM and Tech
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // ! Change AppUser to Requestor and link AppUser to Request
            builder.Entity<Requestor>(x => x.HasKey(aa => new { aa.AppUserId, aa.RequestId }));

            builder.Entity<Requestor>()
                .HasOne(u => u.AppUser)
                .WithMany(r => r.Requestors)
                .HasForeignKey(aa => aa.AppUserId);

            // LEC Requestor to Requests
            builder.Entity<Requestor>()
                .HasOne(r => r.Requests)
                .WithMany(r => r.Requestors)
                .HasForeignKey(r => r.RequestId);

            // LEC Project Manager to Project
            builder.Entity<ProjectManager>()
                .HasOne(p => p.Projects)
                .WithMany(p => p.ProjectManagers)
                .HasForeignKey(p => p.ProjectId);

            // LEC Change Manager to Changes
            builder.Entity<ChangeManager>()
                .HasOne(c => c.Changes)
                .WithMany(c => c.ChangeManagers)
                .HasForeignKey(c => c.ChangeId);

            // LEC Assignee to WorkItem
            builder.Entity<Assignee>()
                .HasOne(a => a.WorkItems)
                .WithMany(a => a.Assignees)
                .HasForeignKey(a => a.WorkItemId);

            // ! Create Relationships for 
            // ! Request to Project 
            // ! Request to Change
            // ! Project to Category
            // ! Change to Category
            // ! Project to Work
            // ! Change to Work
            // ! Work to WorkItem




        }
    }
}