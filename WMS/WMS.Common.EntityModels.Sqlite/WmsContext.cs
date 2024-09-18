using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WMS.Shared;

public partial class WmsContext : DbContext
{
    public WmsContext()
    {
    }

    public WmsContext(DbContextOptions<WmsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApprovalStatus> ApprovalStatuses { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Change> Changes { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Priority> Priorities { get; set; }

    public virtual DbSet<Statuses> Statuses { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<RequestType> RequestTypes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Work> Works { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Filename=../WMS.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        modelBuilder.Entity<Change>(entity =>
        {
            entity.HasKey(e => new { e.ChangeId });
            entity.HasOne(e => e.RequestNavigation)
                .WithMany(e => e.Changes)
                .HasForeignKey(e => e.Request);
            entity.HasOne(e => e.RequestorNavigation)
                .WithMany(e => e.Changes)
                .HasForeignKey(e => e.Requestor);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => new { e.EmployeeId });
        });


        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => new { e.ProjectId });
            entity.HasOne(e => e.Status);
            entity.HasOne(e => e.Category);
            entity.HasOne(e => e.Priority);
            entity.HasOne(e => e.RequestNavigation);
            entity.HasOne(e => e.RequestorNavigation);
            entity.HasMany(e => e.Works);
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => new { e.RequestId });
            entity.HasOne(e => e.RequestType);
            entity.HasOne(e => e.Employee);
            entity.HasOne(e => e.Status);
            entity.HasMany(e => e.Changes);
            entity.HasMany(e => e.Projects);
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
