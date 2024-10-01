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

            /*

            builder.Entity<ApprovalStatus>()
                .HasData(
                    new ApprovalStatus { ApprovalStatusId = Guid.NewGuid(), ApprovalStatusName = "Pending" },
                    new ApprovalStatus { ApprovalStatusId = Guid.NewGuid(), ApprovalStatusName = "Approved" },
                    new ApprovalStatus { ApprovalStatusId = Guid.NewGuid(), ApprovalStatusName = "Denied" }
                );

            builder.Entity<Status>()
                .HasData(
                    new Status { StatusId = Guid.NewGuid(), StatusName = "In-Progress" },
                    new Status { StatusId = Guid.NewGuid(), StatusName = "On-Hold" },
                    new Status { StatusId = Guid.NewGuid(), StatusName = "Cancelled" },
                    new Status { StatusId = Guid.NewGuid(), StatusName = "Completed" },
                    new Status { StatusId = Guid.NewGuid(), StatusName = "Pending" }
                );

            builder.Entity<Priority>()
                .HasData(
                    new Priority { PriorityId = Guid.NewGuid(), PriorityName = "Low" },
                    new Priority { PriorityId = Guid.NewGuid(), PriorityName = "Standard" },
                    new Priority { PriorityId = Guid.NewGuid(), PriorityName = "High" },
                    new Priority { PriorityId = Guid.NewGuid(), PriorityName = "Emergency" }
                );

            builder.Entity<Category>()
                .HasData(
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Infrastructure" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Application Development" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Security" },
                    new Category { CategoryId = Guid.NewGuid(), CategoryName = "Communications" }
                );

            builder.Entity<RequestType>()
                .HasData(
                    new RequestType { RequestTypeId = Guid.NewGuid(), RequestTypeName = "Project Request" },
                    new RequestType { RequestTypeId = Guid.NewGuid(), RequestTypeName = "Change Request" }
                );
            */

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

            // ! defines 1 to 1 relationship between Request and Approval Status
            builder.Entity<Request>()
                .HasOne(a => a.ApprovalStatus)
                .WithOne(b => b.Request)
                .HasForeignKey<ApprovalStatus>(b => b.RequestRef);

            // ! defines 1 to 1 relationship between Request and Status
            builder.Entity<Request>()
                .HasOne(a => a.Status)
                .WithOne(b => b.Request)
                .HasForeignKey<Status>(b => b.RequestRef);

            // ! defines 1 to 1 relationship between Request and RequestType
            builder.Entity<Request>()
                .HasOne(a => a.RequestType)
                .WithOne(b => b.Request)
                .HasForeignKey<RequestType>(b => b.RequestRef);

            // NOTE: CHANGE
            builder.Entity<ChangesToChangeManager>(x => x.HasKey(rr => new { rr.Id, rr.ChangeId }));

            // ! defines a many to many relationship between Employee and Change
            builder.Entity<ChangesToChangeManager>()
                .HasOne(m => m.Employee)
                .WithMany(m => m.Changes)
                .HasForeignKey(rr => rr.Id);

            // ! defines 1 to 1 relationship between Change and Request
            builder.Entity<Change>()
                .HasOne(a => a.Request)
                .WithOne(b => b.Change)
                .HasForeignKey<Request>(b => b.RequestId);

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
            builder.Entity<ProjectToProjectManager>(x => x.HasKey(rr => new { rr.Id, rr.ProjectId }));

            // ! defines a many to many relationship between Employee and Change
            builder.Entity<ProjectToProjectManager>()
                .HasOne(m => m.Employee)
                .WithMany(m => m.Projects)
                .HasForeignKey(rr => rr.Id);

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
            builder.Entity<WorkToWorkItem>(x => x.HasKey(rr => new { rr.WorkId, rr.WorkItemId }));

            builder.Entity<WorkToWorkItem>()
                .HasOne(a => a.Work)
                .WithMany(b => b.WorkItems)
                .HasForeignKey(rr => rr.WorkId);

            // NOTE: WorkItem
            builder.Entity<WorkItem>()
                .HasOne(a => a.Priority)
                .WithOne(b => b.WorkItem)
                .HasForeignKey<Priority>(b => b.WorkItemRef);
        }

    }


}