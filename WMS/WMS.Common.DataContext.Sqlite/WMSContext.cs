using Microsoft.EntityFrameworkCore;
using WMS.Common.EntityModels.Sqlite;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WMS.Common.DataContext.Sqlite
{
    public partial class WMSContext : DbContext
    {
        public WMSContext()
        { }

        public WMSContext(DbContextOptions<WMSContext> options) : base(options)
        {

        }

        // TODO DbSets, OnConfiguring and OnModelCreating 
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Request> Requests { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<Change> Changes { get; set; } = null!;
        public virtual DbSet<Priority> Priorities { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<ApprovalStatus> ApprovalStatuses { get; set; } = null!;
        public virtual DbSet<RequestType> RequestTypes { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
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

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }


}