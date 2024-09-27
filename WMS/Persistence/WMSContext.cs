using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistence
{
    public partial class WMSContext : DbContext
    {
        public WMSContext()
        { }

        public WMSContext(DbContextOptions<WMSContext> options) : base(options)
        {

        }


        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Request> Requests { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<Change> Changes { get; set; } = null!;
        public virtual DbSet<Priority> Priorities { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<ApprovalStatus> ApprovalStatuses { get; set; } = null!;
        public virtual DbSet<RequestType> RequestTypes { get; set; } = null!;

        public virtual DbSet<Work> Works { get; set; } = null!;
        public virtual DbSet<WorkItem> WorkItems { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string dir = Environment.CurrentDirectory;
                string path = string.Empty;

                if (dir.EndsWith("net8.0"))
                {
                    path = Path.Combine("..", "..", "..", "..", "WMS.db");
                }
                else
                {
                    path = Path.Combine("..", "WMS.db");
                }

                optionsBuilder.UseSqlite($"Filename={path}");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // NOTE: REQUEST
            builder.Entity<RequestToRequestors>(x => x.HasKey(rr => new { rr.EmployeeId, rr.RequestId }));

            // ! defines a many to many relationship between Employee and Request
            builder.Entity<RequestToRequestors>()
                .HasOne(m => m.Employee)
                .WithMany(m => m.Requests)
                .HasForeignKey(rr => rr.EmployeeId);

            // ! defines 1 to 1 relationship between Request and Change
            builder.Entity<Request>()
                .HasOne(a => a.Change)
                .WithOne(b => b.Requests)
                .HasForeignKey<Change>(b => b.RequestRef);

            // ! defines 1 to 1 relationship between Request and Project
            builder.Entity<Request>()
                .HasOne(a => a.Project)
                .WithOne(b => b.Request)
                .HasForeignKey<Project>(b => b.RequestRef);

            // ! defines 1 to 1 relationship between Request and Approval Status
            builder.Entity<Request>()
                .HasOne(a => a.ApprovalStatus)
                .WithOne(b => b.Request)
                .HasForeignKey<ApprovalStatus>(b => b.RequestRef);

            // ! defines 1 to 1 relationship between Request and Status
            builder.Entity<Request>()
                .HasOne(a => a.Status)
                .WithOne(b => b.Request)
                .HasForeignKey<ApprovalStatus>(b => b.RequestRef);

            // ! defines 1 to 1 relationship between Request and RequestType
            builder.Entity<Request>()
                .HasOne(a => a.RequestType)
                .WithOne(b => b.Request)
                .HasForeignKey<ApprovalStatus>(b => b.RequestRef);

            // NOTE: CHANGE
            builder.Entity<ChangesToChangeManager>(x => x.HasKey(rr => new { rr.EmployeeId, rr.ChangeId }));

            // ! defines a many to many relationship between Employee and Change
            builder.Entity<ChangesToChangeManager>()
                .HasOne(m => m.Employee)
                .WithMany(m => m.Changes)
                .HasForeignKey(rr => rr.EmployeeId);

            // ! defines 1 to 1 relationship between Change and Request
            builder.Entity<Change>()
                .HasOne(a => a.Requests)
                .WithOne(b => b.Change)
                .HasForeignKey<Project>(b => b.RequestRef);

            // ! defines 1 to 1 relationship between Change and Approval Status
            builder.Entity<Change>()
                .HasOne(a => a.ApprovalStatus)
                .WithOne(b => b.Change)
                .HasForeignKey<ApprovalStatus>(b => b.ChangeRef);

            // ! defines 1 to 1 relationship between Change and Status
            builder.Entity<Change>()
                .HasOne(a => a.Status)
                .WithOne(b => b.Change)
                .HasForeignKey<Status>(b => b.ChangeRef);

            // ! defines 1 to 1 relationship between Change and Priority
            builder.Entity<Change>()
                .HasOne(a => a.Priority)
                .WithOne(b => b.Change)
                .HasForeignKey<Priority>(b => b.ChangeRef);

            // ! defines 1 to 1 relationship between Change and Category
            builder.Entity<Change>()
                .HasOne(a => a.Category)
                .WithOne(b => b.Change)
                .HasForeignKey<Category>(b => b.ChangeRef);

            // ! defines a 1 to many relationship between Change and Work
            builder.Entity<Work>()
                .HasOne(a => a.Change)
                .WithMany(b => b.Works);

            // NOTE: PROJECT
            builder.Entity<ProjectToProjectManager>(x => x.HasKey(rr => new { rr.EmployeeId, rr.ProjectId }));

            // ! defines 1 to 1 relationship between Project and Status
            builder.Entity<Project>()
                .HasOne(a => a.Status)
                .WithOne(b => b.Project)
                .HasForeignKey<Status>(b => b.ProjectRef);

            // ! defines 1 to 1 relationship between Project and Approval Status
            builder.Entity<Project>()
                .HasOne(a => a.ApprovalStatus)
                .WithOne(b => b.Project)
                .HasForeignKey<ApprovalStatus>(b => b.ProjectRef);

            // ! defines 1 to 1 relationship between Project and Priority
            builder.Entity<Project>()
                .HasOne(a => a.Priority)
                .WithOne(b => b.Project)
                .HasForeignKey<Priority>(b => b.ProjectRef);

            // ! defines 1 to 1 relationship between Project and Category
            builder.Entity<Project>()
                .HasOne(a => a.Category)
                .WithOne(b => b.Project)
                .HasForeignKey<Category>(b => b.ProjectRef);

            // ! defines a 1 to many relationship between Project and Work
            builder.Entity<Work>()
                .HasOne(a => a.Project)
                .WithMany(b => b.Works);

            // NOTE: Work
            builder.Entity<Work>(x => x.HasKey(rr => new { rr.WorkId }));

            builder.Entity<Work>()
                .HasMany(a => a.WorkItems)
                .WithOne(b => b.Work);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }


}