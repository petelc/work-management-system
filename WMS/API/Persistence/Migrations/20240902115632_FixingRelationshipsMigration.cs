using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixingRelationshipsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Changes_AspNetUsers_requestorId",
                table: "Changes");

            migrationBuilder.DropForeignKey(
                name: "FK_Changes_Requests_RequestId",
                table: "Changes");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Requests_RequestId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_RequestId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Changes_RequestId",
                table: "Changes");

            migrationBuilder.DropIndex(
                name: "IX_Changes_requestorId",
                table: "Changes");

            migrationBuilder.DropColumn(
                name: "requestorId",
                table: "Changes");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "Projects",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "approvals",
                table: "Projects",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "Changes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "priority",
                table: "Changes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "approvals",
                table: "Changes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "Projects",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "approvals",
                table: "Projects",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "Changes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "priority",
                table: "Changes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "approvals",
                table: "Changes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "requestorId",
                table: "Changes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_RequestId",
                table: "Projects",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Changes_RequestId",
                table: "Changes",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Changes_requestorId",
                table: "Changes",
                column: "requestorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Changes_AspNetUsers_requestorId",
                table: "Changes",
                column: "requestorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Changes_Requests_RequestId",
                table: "Changes",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "RequestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Requests_RequestId",
                table: "Projects",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "RequestId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
