using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace movie_rating_app.Migrations
{
    public partial class AddRolesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MoviesCasts",
                table: "Movies");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_MoviesCasts_MovieId",
                table: "MoviesCasts");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Movies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesCasts_Movies_MovieId",
                table: "MoviesCasts",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviesCasts_Movies_MovieId",
                table: "MoviesCasts");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Movies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_MoviesCasts_MovieId",
                table: "MoviesCasts",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_MoviesCasts",
                table: "Movies",
                column: "Id",
                principalTable: "MoviesCasts",
                principalColumn: "MovieId");
        }
    }
}
