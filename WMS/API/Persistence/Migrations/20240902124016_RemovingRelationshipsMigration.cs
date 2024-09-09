using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemovingRelationshipsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Changes_Requests_ChangeId",
                table: "Changes");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Requests_ProjectId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "ChangeManagers");

            migrationBuilder.DropTable(
                name: "ProjectManagers");

            migrationBuilder.DropColumn(
                name: "approvals",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "type",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "approvals",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Changes");

            migrationBuilder.DropColumn(
                name: "priority",
                table: "Changes");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Changes");

            migrationBuilder.AddColumn<Guid>(
                name: "ChangeId",
                table: "Requests",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "Requests",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ChangeId",
                table: "Requests",
                column: "ChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ProjectId",
                table: "Requests",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Changes_ChangeId",
                table: "Requests",
                column: "ChangeId",
                principalTable: "Changes",
                principalColumn: "ChangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Projects_ProjectId",
                table: "Requests",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Changes_ChangeId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Projects_ProjectId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_ChangeId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_ProjectId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ChangeId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Requests");

            migrationBuilder.AddColumn<int>(
                name: "approvals",
                table: "Requests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "Requests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "Requests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "RequestId",
                table: "Projects",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "approvals",
                table: "Projects",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "Projects",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RequestId",
                table: "Changes",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "priority",
                table: "Changes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "Changes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ChangeManagers",
                columns: table => new
                {
                    AppUserId = table.Column<string>(type: "TEXT", nullable: false),
                    ChangeId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeManagers", x => new { x.AppUserId, x.ChangeId });
                    table.ForeignKey(
                        name: "FK_ChangeManagers_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChangeManagers_Changes_ChangeId",
                        column: x => x.ChangeId,
                        principalTable: "Changes",
                        principalColumn: "ChangeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectManagers",
                columns: table => new
                {
                    AppUserId = table.Column<string>(type: "TEXT", nullable: false),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectManagers", x => new { x.AppUserId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_ProjectManagers_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectManagers_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChangeManagers_ChangeId",
                table: "ChangeManagers",
                column: "ChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectManagers_ProjectId",
                table: "ProjectManagers",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Changes_Requests_ChangeId",
                table: "Changes",
                column: "ChangeId",
                principalTable: "Requests",
                principalColumn: "RequestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Requests_ProjectId",
                table: "Projects",
                column: "ProjectId",
                principalTable: "Requests",
                principalColumn: "RequestId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
