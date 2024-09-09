using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RequestRelationMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Changes_Requests_requestsRequestId",
                table: "Changes");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Requests_RequestId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Changes_requestsRequestId",
                table: "Changes");

            migrationBuilder.DropColumn(
                name: "requestsRequestId",
                table: "Changes");

            migrationBuilder.AlterColumn<Guid>(
                name: "RequestId",
                table: "Projects",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RequestId",
                table: "Changes",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Changes_RequestId",
                table: "Changes",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Changes_Requests_ChangeId",
                table: "Changes",
                column: "ChangeId",
                principalTable: "Requests",
                principalColumn: "RequestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Changes_Requests_RequestId",
                table: "Changes",
                column: "RequestId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Requests_RequestId",
                table: "Projects",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "RequestId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Changes_Requests_ChangeId",
                table: "Changes");

            migrationBuilder.DropForeignKey(
                name: "FK_Changes_Requests_RequestId",
                table: "Changes");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Requests_ProjectId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Requests_RequestId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Changes_RequestId",
                table: "Changes");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Changes");

            migrationBuilder.AlterColumn<Guid>(
                name: "RequestId",
                table: "Projects",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddColumn<Guid>(
                name: "requestsRequestId",
                table: "Changes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Changes_requestsRequestId",
                table: "Changes",
                column: "requestsRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Changes_Requests_requestsRequestId",
                table: "Changes",
                column: "requestsRequestId",
                principalTable: "Requests",
                principalColumn: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Requests_RequestId",
                table: "Projects",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "RequestId");
        }
    }
}
