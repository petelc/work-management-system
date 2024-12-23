using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ADDCABMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CABRef",
                table: "Projects",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CABRef",
                table: "Changes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CABs",
                columns: table => new
                {
                    CABId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RequestName = table.Column<string>(type: "TEXT", nullable: false),
                    RequestId = table.Column<int>(type: "INTEGER", nullable: false),
                    RequestRef = table.Column<int>(type: "INTEGER", nullable: false),
                    Votes = table.Column<int>(type: "INTEGER", nullable: false),
                    MemberRef = table.Column<int>(type: "INTEGER", nullable: false),
                    ChangeId = table.Column<int>(type: "INTEGER", nullable: true),
                    ProjectId = table.Column<int>(type: "INTEGER", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    isActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CABs", x => x.CABId);
                    table.ForeignKey(
                        name: "FK_CABs_AspNetUsers_MemberRef",
                        column: x => x.MemberRef,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CABs_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CABRef",
                table: "Projects",
                column: "CABRef",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Changes_CABRef",
                table: "Changes",
                column: "CABRef",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CABs_MemberRef",
                table: "CABs",
                column: "MemberRef");

            migrationBuilder.CreateIndex(
                name: "IX_CABs_RequestId",
                table: "CABs",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Changes_CABs_CABRef",
                table: "Changes",
                column: "CABRef",
                principalTable: "CABs",
                principalColumn: "CABId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_CABs_CABRef",
                table: "Projects",
                column: "CABRef",
                principalTable: "CABs",
                principalColumn: "CABId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Changes_CABs_CABRef",
                table: "Changes");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_CABs_CABRef",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "CABs");

            migrationBuilder.DropIndex(
                name: "IX_Projects_CABRef",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Changes_CABRef",
                table: "Changes");

            migrationBuilder.DropColumn(
                name: "CABRef",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "CABRef",
                table: "Changes");
        }
    }
}
