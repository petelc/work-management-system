using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CAB2Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CABs_AspNetUsers_MemberRef",
                table: "CABs");

            migrationBuilder.DropForeignKey(
                name: "FK_CABs_Requests_RequestId",
                table: "CABs");

            migrationBuilder.DropForeignKey(
                name: "FK_Changes_CABs_CABRef",
                table: "Changes");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_CABs_CABRef",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_CABRef",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Changes_CABRef",
                table: "Changes");

            migrationBuilder.DropIndex(
                name: "IX_CABs_MemberRef",
                table: "CABs");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "CABs",
                newName: "ProjectRef");

            migrationBuilder.RenameColumn(
                name: "ChangeId",
                table: "CABs",
                newName: "MemberId");

            migrationBuilder.AlterColumn<int>(
                name: "RequestRef",
                table: "CABs",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "RequestId",
                table: "CABs",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "MemberRef",
                table: "CABs",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "ChangeRef",
                table: "CABs",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CABs_ChangeRef",
                table: "CABs",
                column: "ChangeRef",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CABs_MemberId",
                table: "CABs",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_CABs_ProjectRef",
                table: "CABs",
                column: "ProjectRef",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CABs_AspNetUsers_MemberId",
                table: "CABs",
                column: "MemberId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CABs_Changes_ChangeRef",
                table: "CABs",
                column: "ChangeRef",
                principalTable: "Changes",
                principalColumn: "ChangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CABs_Projects_ProjectRef",
                table: "CABs",
                column: "ProjectRef",
                principalTable: "Projects",
                principalColumn: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_CABs_Requests_RequestId",
                table: "CABs",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "RequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CABs_AspNetUsers_MemberId",
                table: "CABs");

            migrationBuilder.DropForeignKey(
                name: "FK_CABs_Changes_ChangeRef",
                table: "CABs");

            migrationBuilder.DropForeignKey(
                name: "FK_CABs_Projects_ProjectRef",
                table: "CABs");

            migrationBuilder.DropForeignKey(
                name: "FK_CABs_Requests_RequestId",
                table: "CABs");

            migrationBuilder.DropIndex(
                name: "IX_CABs_ChangeRef",
                table: "CABs");

            migrationBuilder.DropIndex(
                name: "IX_CABs_MemberId",
                table: "CABs");

            migrationBuilder.DropIndex(
                name: "IX_CABs_ProjectRef",
                table: "CABs");

            migrationBuilder.DropColumn(
                name: "ChangeRef",
                table: "CABs");

            migrationBuilder.RenameColumn(
                name: "ProjectRef",
                table: "CABs",
                newName: "ProjectId");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "CABs",
                newName: "ChangeId");

            migrationBuilder.AlterColumn<int>(
                name: "RequestRef",
                table: "CABs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RequestId",
                table: "CABs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MemberRef",
                table: "CABs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_CABs_AspNetUsers_MemberRef",
                table: "CABs",
                column: "MemberRef",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CABs_Requests_RequestId",
                table: "CABs",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "RequestId",
                onDelete: ReferentialAction.Cascade);

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
    }
}
