﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(WMSContext))]
    partial class WMSContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Domain.ApprovalStatus", b =>
                {
                    b.Property<Guid>("ApprovalStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ApprovalStatusName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ChangeRef")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProjectRef")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RequestRef")
                        .HasColumnType("TEXT");

                    b.HasKey("ApprovalStatusId");

                    b.HasIndex("ChangeRef")
                        .IsUnique();

                    b.HasIndex("ProjectRef")
                        .IsUnique();

                    b.HasIndex("RequestRef")
                        .IsUnique();

                    b.ToTable("ApprovalStatuses");
                });

            modelBuilder.Entity("Domain.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ChangeRef")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("BLOB");

                    b.Property<Guid>("ProjectRef")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.HasIndex("ChangeRef")
                        .IsUnique();

                    b.HasIndex("ProjectRef")
                        .IsUnique();

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Domain.Change", b =>
                {
                    b.Property<Guid>("ChangeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ChangeName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RequestRef")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RequestorId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("RequestorRef")
                        .HasColumnType("TEXT");

                    b.HasKey("ChangeId");

                    b.HasIndex("RequestorId");

                    b.ToTable("Changes");
                });

            modelBuilder.Entity("Domain.ChangesToChangeManager", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ChangeId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsNew")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id", "ChangeId");

                    b.HasIndex("ChangeId");

                    b.ToTable("ChangesToChangeManager");
                });

            modelBuilder.Entity("Domain.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Extension")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Institution")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Region")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ReportsTo")
                        .HasColumnType("TEXT");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Domain.Priority", b =>
                {
                    b.Property<Guid>("PriorityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ChangeRef")
                        .HasColumnType("TEXT");

                    b.Property<string>("PriorityName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProjectRef")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("RequestId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RequestRef")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("WorkItemRef")
                        .HasColumnType("TEXT");

                    b.HasKey("PriorityId");

                    b.HasIndex("ChangeRef")
                        .IsUnique();

                    b.HasIndex("ProjectRef")
                        .IsUnique();

                    b.HasIndex("RequestId");

                    b.HasIndex("WorkItemRef")
                        .IsUnique();

                    b.ToTable("Priorities");
                });

            modelBuilder.Entity("Domain.Project", b =>
                {
                    b.Property<Guid>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RequestRef")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RequestorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProjectId");

                    b.HasIndex("RequestRef")
                        .IsUnique();

                    b.HasIndex("RequestorId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Domain.ProjectToProjectManager", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsNew")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectToProjectManager");
                });

            modelBuilder.Entity("Domain.Request", b =>
                {
                    b.Property<Guid>("RequestId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsNew")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RequestTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("RequestId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("Domain.RequestToRequestors", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("RequestId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsNew")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id", "RequestId");

                    b.HasIndex("RequestId");

                    b.ToTable("RequestToRequestors");
                });

            modelBuilder.Entity("Domain.RequestType", b =>
                {
                    b.Property<Guid>("RequestTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ChangeId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ChangeRef")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProjectRef")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RequestRef")
                        .HasColumnType("TEXT");

                    b.Property<string>("RequestTypeName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("RequestTypeId");

                    b.HasIndex("ChangeId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("RequestRef")
                        .IsUnique();

                    b.ToTable("RequestTypes");
                });

            modelBuilder.Entity("Domain.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Staff",
                            NormalizedName = "STAFF"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Change Manager",
                            NormalizedName = "CHANGE MANAGER"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Project Manager",
                            NormalizedName = "PROJECT MANAGER"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Board Memeber",
                            NormalizedName = "BOARD MEMBER"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Developer",
                            NormalizedName = "DEVELOPER"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Tech",
                            NormalizedName = "TECH"
                        });
                });

            modelBuilder.Entity("Domain.Status", b =>
                {
                    b.Property<Guid>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ChangeRef")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProjectRef")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RequestRef")
                        .HasColumnType("TEXT");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("StatusId");

                    b.HasIndex("ChangeRef")
                        .IsUnique();

                    b.HasIndex("ProjectRef")
                        .IsUnique();

                    b.HasIndex("RequestRef")
                        .IsUnique();

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("Domain.Work", b =>
                {
                    b.Property<Guid>("WorkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ChangeId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("TEXT");

                    b.HasKey("WorkId");

                    b.HasIndex("ChangeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Works");
                });

            modelBuilder.Entity("Domain.WorkItem", b =>
                {
                    b.Property<Guid>("WorkItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("AssigneeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CardIDNum")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Header")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("WorkItemId");

                    b.HasIndex("AssigneeId");

                    b.ToTable("WorkItems");
                });

            modelBuilder.Entity("Domain.WorkToWorkItem", b =>
                {
                    b.Property<Guid>("WorkId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("WorkItemId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("INTEGER");

                    b.HasKey("WorkId", "WorkItemId");

                    b.HasIndex("WorkItemId");

                    b.ToTable("WorkToWorkItem");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Domain.ApprovalStatus", b =>
                {
                    b.HasOne("Domain.Change", "Change")
                        .WithOne("ApprovalStatus")
                        .HasForeignKey("Domain.ApprovalStatus", "ChangeRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Project", "Project")
                        .WithOne("ApprovalStatus")
                        .HasForeignKey("Domain.ApprovalStatus", "ProjectRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Request", "Request")
                        .WithOne("ApprovalStatus")
                        .HasForeignKey("Domain.ApprovalStatus", "RequestRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Change");

                    b.Navigation("Project");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("Domain.Category", b =>
                {
                    b.HasOne("Domain.Change", "Change")
                        .WithOne("Category")
                        .HasForeignKey("Domain.Category", "ChangeRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Project", "Project")
                        .WithOne("Category")
                        .HasForeignKey("Domain.Category", "ProjectRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Change");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Domain.Change", b =>
                {
                    b.HasOne("Domain.Employee", "Requestor")
                        .WithMany()
                        .HasForeignKey("RequestorId");

                    b.Navigation("Requestor");
                });

            modelBuilder.Entity("Domain.ChangesToChangeManager", b =>
                {
                    b.HasOne("Domain.Change", "Change")
                        .WithMany("ChangeManagers")
                        .HasForeignKey("ChangeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Employee", "Employee")
                        .WithMany("Changes")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Change");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Domain.Priority", b =>
                {
                    b.HasOne("Domain.Change", "Change")
                        .WithOne("Priority")
                        .HasForeignKey("Domain.Priority", "ChangeRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Project", "Project")
                        .WithOne("Priority")
                        .HasForeignKey("Domain.Priority", "ProjectRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Request", "Request")
                        .WithMany()
                        .HasForeignKey("RequestId");

                    b.HasOne("Domain.WorkItem", "WorkItem")
                        .WithOne("Priority")
                        .HasForeignKey("Domain.Priority", "WorkItemRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Change");

                    b.Navigation("Project");

                    b.Navigation("Request");

                    b.Navigation("WorkItem");
                });

            modelBuilder.Entity("Domain.Project", b =>
                {
                    b.HasOne("Domain.Request", "Request")
                        .WithOne("Project")
                        .HasForeignKey("Domain.Project", "RequestRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Employee", "Requestor")
                        .WithMany()
                        .HasForeignKey("RequestorId");

                    b.Navigation("Request");

                    b.Navigation("Requestor");
                });

            modelBuilder.Entity("Domain.ProjectToProjectManager", b =>
                {
                    b.HasOne("Domain.Employee", "Employee")
                        .WithMany("Projects")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Project", "Project")
                        .WithMany("ProjectManagers")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Domain.Request", b =>
                {
                    b.HasOne("Domain.Change", "Change")
                        .WithOne("Request")
                        .HasForeignKey("Domain.Request", "RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Change");
                });

            modelBuilder.Entity("Domain.RequestToRequestors", b =>
                {
                    b.HasOne("Domain.Employee", "Employee")
                        .WithMany("Requests")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Request", "Request")
                        .WithMany("Requestors")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("Domain.RequestType", b =>
                {
                    b.HasOne("Domain.Change", "Change")
                        .WithMany()
                        .HasForeignKey("ChangeId");

                    b.HasOne("Domain.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");

                    b.HasOne("Domain.Request", "Request")
                        .WithOne("RequestType")
                        .HasForeignKey("Domain.RequestType", "RequestRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Change");

                    b.Navigation("Project");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("Domain.Status", b =>
                {
                    b.HasOne("Domain.Change", "Change")
                        .WithOne("Status")
                        .HasForeignKey("Domain.Status", "ChangeRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Project", "Project")
                        .WithOne("Status")
                        .HasForeignKey("Domain.Status", "ProjectRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Request", "Request")
                        .WithOne("Status")
                        .HasForeignKey("Domain.Status", "RequestRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Change");

                    b.Navigation("Project");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("Domain.Work", b =>
                {
                    b.HasOne("Domain.Change", "Change")
                        .WithMany("Works")
                        .HasForeignKey("ChangeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Project", "Project")
                        .WithMany("Works")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Change");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Domain.WorkItem", b =>
                {
                    b.HasOne("Domain.Employee", "Assignee")
                        .WithMany()
                        .HasForeignKey("AssigneeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignee");
                });

            modelBuilder.Entity("Domain.WorkToWorkItem", b =>
                {
                    b.HasOne("Domain.Work", "Work")
                        .WithMany("WorkItems")
                        .HasForeignKey("WorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.WorkItem", "WorkItem")
                        .WithMany("Work")
                        .HasForeignKey("WorkItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Work");

                    b.Navigation("WorkItem");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Domain.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Domain.Employee", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Domain.Employee", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Domain.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Employee", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Domain.Employee", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Change", b =>
                {
                    b.Navigation("ApprovalStatus");

                    b.Navigation("Category");

                    b.Navigation("ChangeManagers");

                    b.Navigation("Priority");

                    b.Navigation("Request");

                    b.Navigation("Status");

                    b.Navigation("Works");
                });

            modelBuilder.Entity("Domain.Employee", b =>
                {
                    b.Navigation("Changes");

                    b.Navigation("Projects");

                    b.Navigation("Requests");
                });

            modelBuilder.Entity("Domain.Project", b =>
                {
                    b.Navigation("ApprovalStatus");

                    b.Navigation("Category");

                    b.Navigation("Priority");

                    b.Navigation("ProjectManagers");

                    b.Navigation("Status");

                    b.Navigation("Works");
                });

            modelBuilder.Entity("Domain.Request", b =>
                {
                    b.Navigation("ApprovalStatus");

                    b.Navigation("Project");

                    b.Navigation("RequestType");

                    b.Navigation("Requestors");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Domain.Work", b =>
                {
                    b.Navigation("WorkItems");
                });

            modelBuilder.Entity("Domain.WorkItem", b =>
                {
                    b.Navigation("Priority")
                        .IsRequired();

                    b.Navigation("Work");
                });
#pragma warning restore 612, 618
        }
    }
}
