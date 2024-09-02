using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AdjustedProjectsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_requestorId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_requestorId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "requestorId",
                table: "Projects");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "requestorId",
                table: "Projects",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_requestorId",
                table: "Projects",
                column: "requestorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_requestorId",
                table: "Projects",
                column: "requestorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
