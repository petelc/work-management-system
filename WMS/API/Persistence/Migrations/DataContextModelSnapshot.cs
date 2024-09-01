﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Domain.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bio")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

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

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
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

            modelBuilder.Entity("Domain.Assignee", b =>
                {
                    b.Property<string>("AppUserId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("WorkItemId")
                        .HasColumnType("TEXT");

                    b.HasKey("AppUserId", "WorkItemId");

                    b.HasIndex("WorkItemId");

                    b.ToTable("Assignees");
                });

            modelBuilder.Entity("Domain.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Domain.Change", b =>
                {
                    b.Property<Guid>("ChangeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("TEXT");

                    b.Property<int>("approvals")
                        .HasColumnType("INTEGER");

                    b.Property<string>("change")
                        .HasColumnType("TEXT");

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<int>("priority")
                        .HasColumnType("INTEGER");

                    b.Property<string>("requestorId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("requestsRequestId")
                        .HasColumnType("TEXT");

                    b.Property<int>("status")
                        .HasColumnType("INTEGER");

                    b.HasKey("ChangeId")
                        .HasName("PK_ChangeId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("requestorId");

                    b.HasIndex("requestsRequestId");

                    b.ToTable("Changes");
                });

            modelBuilder.Entity("Domain.ChangeManager", b =>
                {
                    b.Property<string>("AppUserId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ChangeId")
                        .HasColumnType("TEXT");

                    b.HasKey("AppUserId", "ChangeId");

                    b.HasIndex("ChangeId");

                    b.ToTable("ChangeManagers");
                });

            modelBuilder.Entity("Domain.Icon", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("IconUrl")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Icons");
                });

            modelBuilder.Entity("Domain.Project", b =>
                {
                    b.Property<Guid>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("RequestId")
                        .HasColumnType("TEXT");

                    b.Property<int>("approvals")
                        .HasColumnType("INTEGER");

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<string>("project")
                        .HasColumnType("TEXT");

                    b.Property<string>("requestorId")
                        .HasColumnType("TEXT");

                    b.Property<int>("status")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProjectId")
                        .HasName("PK_ProjectId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("RequestId");

                    b.HasIndex("requestorId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Domain.ProjectManager", b =>
                {
                    b.Property<string>("AppUserId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("TEXT");

                    b.HasKey("AppUserId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectManagers");
                });

            modelBuilder.Entity("Domain.Request", b =>
                {
                    b.Property<Guid>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AppUserId")
                        .HasColumnType("TEXT");

                    b.Property<int>("approvals")
                        .HasColumnType("INTEGER");

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<string>("request")
                        .HasColumnType("TEXT");

                    b.Property<int>("status")
                        .HasColumnType("INTEGER");

                    b.Property<int>("type")
                        .HasColumnType("INTEGER");

                    b.HasKey("RequestId")
                        .HasName("PK_RequestId");

                    b.HasIndex("AppUserId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("Domain.Requestor", b =>
                {
                    b.Property<string>("AppUserId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RequestId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsNew")
                        .HasColumnType("INTEGER");

                    b.HasKey("AppUserId", "RequestId");

                    b.HasIndex("RequestId");

                    b.ToTable("Requestors");
                });

            modelBuilder.Entity("Domain.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AppUserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Domain.Work", b =>
                {
                    b.Property<Guid>("WorkId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("WorkId")
                        .HasName("PK_WorkId");

                    b.ToTable("Works");
                });

            modelBuilder.Entity("Domain.WorkItem", b =>
                {
                    b.Property<Guid>("WorkItemId")
                        .HasColumnType("TEXT");

                    b.Property<string>("AssigneeId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CardNum")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("Iconid")
                        .HasColumnType("TEXT");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("WorkItemId")
                        .HasName("PK_WorkItemId");

                    b.HasIndex("AssigneeId");

                    b.HasIndex("Iconid");

                    b.ToTable("WorkItems");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

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
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Domain.Assignee", b =>
                {
                    b.HasOne("Domain.AppUser", "AppUser")
                        .WithMany("Assignees")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.WorkItem", "WorkItems")
                        .WithMany("Assignees")
                        .HasForeignKey("WorkItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("WorkItems");
                });

            modelBuilder.Entity("Domain.Change", b =>
                {
                    b.HasOne("Domain.Category", "category")
                        .WithMany("Changes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Domain.AppUser", "requestor")
                        .WithMany()
                        .HasForeignKey("requestorId");

                    b.HasOne("Domain.Request", "requests")
                        .WithMany()
                        .HasForeignKey("requestsRequestId");

                    b.Navigation("category");

                    b.Navigation("requestor");

                    b.Navigation("requests");
                });

            modelBuilder.Entity("Domain.ChangeManager", b =>
                {
                    b.HasOne("Domain.AppUser", "AppUser")
                        .WithMany("ChangeManagers")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Change", "Changes")
                        .WithMany("ChangeManagers")
                        .HasForeignKey("ChangeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Changes");
                });

            modelBuilder.Entity("Domain.Project", b =>
                {
                    b.HasOne("Domain.Category", "category")
                        .WithMany("Projects")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Domain.Request", "request")
                        .WithMany()
                        .HasForeignKey("RequestId");

                    b.HasOne("Domain.AppUser", "requestor")
                        .WithMany()
                        .HasForeignKey("requestorId");

                    b.Navigation("category");

                    b.Navigation("request");

                    b.Navigation("requestor");
                });

            modelBuilder.Entity("Domain.ProjectManager", b =>
                {
                    b.HasOne("Domain.AppUser", "AppUser")
                        .WithMany("ProjectManagers")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Project", "Projects")
                        .WithMany("ProjectManagers")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Domain.Request", b =>
                {
                    b.HasOne("Domain.AppUser", null)
                        .WithMany("Requests")
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("Domain.Requestor", b =>
                {
                    b.HasOne("Domain.AppUser", "AppUser")
                        .WithMany("Requestors")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Request", "Requests")
                        .WithMany("Requestors")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Requests");
                });

            modelBuilder.Entity("Domain.Role", b =>
                {
                    b.HasOne("Domain.AppUser", null)
                        .WithMany("Roles")
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("Domain.Work", b =>
                {
                    b.HasOne("Domain.Change", "Change")
                        .WithMany("Works")
                        .HasForeignKey("WorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Project", "Project")
                        .WithMany("Works")
                        .HasForeignKey("WorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Change");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Domain.WorkItem", b =>
                {
                    b.HasOne("Domain.AppUser", "Assignee")
                        .WithMany()
                        .HasForeignKey("AssigneeId");

                    b.HasOne("Domain.Icon", "Icon")
                        .WithMany()
                        .HasForeignKey("Iconid");

                    b.HasOne("Domain.Work", "Work")
                        .WithMany("WorkItems")
                        .HasForeignKey("WorkItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignee");

                    b.Navigation("Icon");

                    b.Navigation("Work");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.AppUser", b =>
                {
                    b.Navigation("Assignees");

                    b.Navigation("ChangeManagers");

                    b.Navigation("ProjectManagers");

                    b.Navigation("Requestors");

                    b.Navigation("Requests");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("Domain.Category", b =>
                {
                    b.Navigation("Changes");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Domain.Change", b =>
                {
                    b.Navigation("ChangeManagers");

                    b.Navigation("Works");
                });

            modelBuilder.Entity("Domain.Project", b =>
                {
                    b.Navigation("ProjectManagers");

                    b.Navigation("Works");
                });

            modelBuilder.Entity("Domain.Request", b =>
                {
                    b.Navigation("Requestors");
                });

            modelBuilder.Entity("Domain.Work", b =>
                {
                    b.Navigation("WorkItems");
                });

            modelBuilder.Entity("Domain.WorkItem", b =>
                {
                    b.Navigation("Assignees");
                });
#pragma warning restore 612, 618
        }
    }
}
