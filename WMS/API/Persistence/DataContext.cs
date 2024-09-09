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

        /**
        * TODO - Create a relationship between Request and Project 
        * TODO - Create a relationship betwwn Request and Change 
        */


        public DbSet<Request> Requests { get; set; }
        public DbSet<Requestor> Requestors { get; set; }
        public DbSet<Project> Projects { get; set; }

        //public DbSet<ProjectManager> ProjectManagers { get; set; }
        //public DbSet<ChangeManager> ChangeManagers { get; set; }
        public DbSet<Assignee> Assignees { get; set; }

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

            // builder.Entity<ProjectManager>(p => p.HasKey(pp => new { pp.AppUserId, pp.ProjectId }));
            // // LEC Project Manager to Project
            // builder.Entity<ProjectManager>()
            //     .HasOne(p => p.Projects)
            //     .WithMany(p => p.ProjectManagers)
            //     .HasForeignKey(p => p.ProjectId);

            // builder.Entity<ChangeManager>(c => c.HasKey(cc => new { cc.AppUserId, cc.ChangeId }));
            // // LEC Change Manager to Changes
            // builder.Entity<ChangeManager>()
            //     .HasOne(c => c.Changes)
            //     .WithMany(c => c.ChangeManagers)
            //     .HasForeignKey(c => c.ChangeId);

            builder.Entity<Assignee>(k => k.HasKey(kk => new { kk.AppUserId, kk.WorkItemId }));
            // LEC Assignee to WorkItem
            builder.Entity<Assignee>()
                .HasOne(a => a.WorkItems)
                .WithMany(a => a.Assignees)
                .HasForeignKey(a => a.WorkItemId);

            // ! Create Primary Keys for Models
            builder.Entity<Request>()
                .HasKey(r => r.RequestId)
                .HasName("PK_RequestId");

            builder.Entity<Project>()
                .HasKey(p => p.ProjectId)
                .HasName("PK_ProjectId");

            builder.Entity<Change>()
                .HasKey(c => c.ChangeId)
                .HasName("PK_ChangeId");

            builder.Entity<Work>()
                .HasKey(w => w.WorkId)
                .HasName("PK_WorkId");

            builder.Entity<WorkItem>()
                .HasKey(wi => wi.WorkItemId)
                .HasName("PK_WorkItemId");

            // ! Create Relationships for 
            // -- Request to Project 
            // -- Request to Change
            // -- Project to Category
            // -- Change to Category
            // -- Project to Work
            // -- Change to Work
            // -- Work to WorkItem

            // builder.Entity<Request>()
            //     .HasOne(e => e.Project)
            //     .WithOne(e => e.Request)
            //     .HasForeignKey<Project>(e => e.ProjectId);

            // builder.Entity<Request>()
            //     .HasOne(e => e.Change)
            //     .WithOne(e => e.Request)
            //     .HasForeignKey<Change>(e => e.ChangeId);

            // builder.Entity<Project>()
            //     .HasOne(c => c.category)
            //     .WithMany(c => c.Projects)
            //     .OnDelete(DeleteBehavior.NoAction);

            // builder.Entity<Change>()
            //     .HasOne(c => c.category)
            //     .WithMany(c => c.Changes)
            //     .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Work>()
                .HasOne(p => p.Project)
                .WithMany(p => p.Works)
                .HasForeignKey(p => p.WorkId);

            builder.Entity<Work>()
                .HasOne(p => p.Change)
                .WithMany(p => p.Works)
                .HasForeignKey(p => p.WorkId);

            builder.Entity<WorkItem>()
                .HasOne(p => p.Work)
                .WithMany(p => p.WorkItems)
                .HasForeignKey(p => p.WorkItemId);

        }
    }
}