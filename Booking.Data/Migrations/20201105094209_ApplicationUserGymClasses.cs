using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.Data.Migrations
{
    public partial class ApplicationUserGymClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserGymClass_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserGymClass");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserGymClass_GymClasses_GymClassId",
                table: "ApplicationUserGymClass");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserGymClass",
                table: "ApplicationUserGymClass");

            migrationBuilder.RenameTable(
                name: "ApplicationUserGymClass",
                newName: "ApplicationUserGymClasses");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserGymClass_GymClassId",
                table: "ApplicationUserGymClasses",
                newName: "IX_ApplicationUserGymClasses_GymClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserGymClasses",
                table: "ApplicationUserGymClasses",
                columns: new[] { "ApplicationUserId", "GymClassId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserGymClasses_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserGymClasses",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserGymClasses_GymClasses_GymClassId",
                table: "ApplicationUserGymClasses",
                column: "GymClassId",
                principalTable: "GymClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserGymClasses_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserGymClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserGymClasses_GymClasses_GymClassId",
                table: "ApplicationUserGymClasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserGymClasses",
                table: "ApplicationUserGymClasses");

            migrationBuilder.RenameTable(
                name: "ApplicationUserGymClasses",
                newName: "ApplicationUserGymClass");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserGymClasses_GymClassId",
                table: "ApplicationUserGymClass",
                newName: "IX_ApplicationUserGymClass_GymClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserGymClass",
                table: "ApplicationUserGymClass",
                columns: new[] { "ApplicationUserId", "GymClassId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserGymClass_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserGymClass",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserGymClass_GymClasses_GymClassId",
                table: "ApplicationUserGymClass",
                column: "GymClassId",
                principalTable: "GymClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
