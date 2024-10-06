using Microsoft.EntityFrameworkCore;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Persistence
{
    public class WMSContext : IdentityDbContext<Employee, Role, int>
    {
        public WMSContext(DbContextOptions options) : base(options)
        {
        }

        //public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Request> Requests { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Project> Projects { get; set; } = null!;
        public DbSet<Change> Changes { get; set; } = null!;
        public DbSet<Priority> Priorities { get; set; } = null!;
        public DbSet<Status> Statuses { get; set; } = null!;
        public DbSet<ApprovalStatus> ApprovalStatuses { get; set; } = null!;
        public DbSet<RequestType> RequestTypes { get; set; } = null!;
        public DbSet<Work> Works { get; set; } = null!;
        public DbSet<WorkItem> WorkItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<Role>()
                .HasData(
                    new Role { Id = 1, Name = "Staff", NormalizedName = "STAFF" },
                    new Role { Id = 2, Name = "Change Manager", NormalizedName = "CHANGE MANAGER" },
                    new Role { Id = 3, Name = "Project Manager", NormalizedName = "PROJECT MANAGER" },
                    new Role { Id = 4, Name = "Board Memeber", NormalizedName = "BOARD MEMBER" },
                    new Role { Id = 5, Name = "Developer", NormalizedName = "DEVELOPER" },
                    new Role { Id = 6, Name = "Tech", NormalizedName = "TECH" }
                );

            // NOTE: REQUEST
            builder.Entity<RequestToRequestors>(x => x.HasKey(rr => new { rr.Id, rr.RequestId }));

            // ! defines a many to many relationship between Employee and Request
            builder.Entity<RequestToRequestors>()
                .HasOne(m => m.Employee)
                .WithMany(m => m.Requests)
                .HasForeignKey(rr => rr.Id);

            // ! defines 1 to 1 relationship between Request and Change
            builder.Entity<Request>()
                .HasOne(a => a.Change)
                .WithOne(b => b.Request)
                .HasForeignKey<Change>(b => b.RequestRef);

            // ! defines 1 to 1 relationship between Request and Project
            builder.Entity<Request>()
                .HasOne(a => a.Project)
                .WithOne(b => b.Request)
                .HasForeignKey<Project>(b => b.RequestRef);

            // NOTE: CHANGE
            builder.Entity<ChangesToChangeManager>(x => x.HasKey(rr => new { rr.Id, rr.ChangeId }));

            // ! defines a many to many relationship between Employee and Change
            builder.Entity<ChangesToChangeManager>()
                .HasOne(m => m.Employee)
                .WithMany(m => m.Changes)
                .HasForeignKey(rr => rr.Id);


            // ! defines a 1 to many relationship between Change and Work
            builder.Entity<Work>()
                .HasOne(a => a.Change)
                .WithMany(b => b.Works);

            // NOTE: PROJECT
            builder.Entity<ProjectToProjectManager>(x => x.HasKey(rr => new { rr.Id, rr.ProjectId }));

            // ! defines a many to many relationship between Employee and Change
            builder.Entity<ProjectToProjectManager>()
                .HasOne(m => m.Employee)
                .WithMany(m => m.Projects)
                .HasForeignKey(rr => rr.Id);


            // ! defines a 1 to many relationship between Project and Work
            builder.Entity<Work>()
                .HasOne(a => a.Project)
                .WithMany(b => b.Works);

            // NOTE: Work
            builder.Entity<WorkToWorkItem>(x => x.HasKey(rr => new { rr.WorkId, rr.WorkItemId }));

            builder.Entity<WorkToWorkItem>()
                .HasOne(a => a.Work)
                .WithMany(b => b.WorkItems)
                .HasForeignKey(rr => rr.WorkId);



            builder.Entity<ApprovalStatus>()
                .HasData(
                    new ApprovalStatus { ApprovalStatusId = 1, ApprovalStatusName = "Pending" },
                    new ApprovalStatus { ApprovalStatusId = 2, ApprovalStatusName = "Approved" },
                    new ApprovalStatus { ApprovalStatusId = 3, ApprovalStatusName = "Denied" }
                );

            builder.Entity<Status>()
                .HasData(
                    new Status { StatusId = 1, StatusName = "In-Progress" },
                    new Status { StatusId = 2, StatusName = "On-Hold" },
                    new Status { StatusId = 3, StatusName = "Cancelled" },
                    new Status { StatusId = 4, StatusName = "Completed" },
                    new Status { StatusId = 5, StatusName = "Pending" }
                );

            builder.Entity<Priority>()
                .HasData(
                    new Priority { PriorityId = 1, PriorityName = "Low" },
                    new Priority { PriorityId = 2, PriorityName = "Standard" },
                    new Priority { PriorityId = 3, PriorityName = "High" },
                    new Priority { PriorityId = 4, PriorityName = "Emergency" }
                );

            builder.Entity<Category>()
                .HasData(
                    new Category { CategoryId = 1, CategoryName = "Infrastructure" },
                    new Category { CategoryId = 2, CategoryName = "Application Development" },
                    new Category { CategoryId = 3, CategoryName = "Security" },
                    new Category { CategoryId = 4, CategoryName = "Communications" }
                );

            builder.Entity<RequestType>()
                .HasData(
                    new RequestType { RequestTypeId = 1, RequestTypeName = "Project Request" },
                    new RequestType { RequestTypeId = 2, RequestTypeName = "Change Request" }
                );
        }

    }


}