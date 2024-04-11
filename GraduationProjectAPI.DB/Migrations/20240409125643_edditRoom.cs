using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProjectAPI.DB.Migrations
{
    /// <inheritdoc />
    public partial class edditRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RoomImages_RoomId",
                table: "RoomImages",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomImages_Rooms_RoomId",
                table: "RoomImages",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomImages_Rooms_RoomId",
                table: "RoomImages");

            migrationBuilder.DropIndex(
                name: "IX_RoomImages_RoomId",
                table: "RoomImages");
        }
    }
}
