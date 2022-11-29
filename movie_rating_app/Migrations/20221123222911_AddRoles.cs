using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace movie_rating_app.Migrations
{
    public partial class AddRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Creators");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "MoviesCasts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "MovieCreators",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoviesCasts_RoleId",
                table: "MoviesCasts",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCreators_RoleId",
                table: "MovieCreators",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCreators_Roles_RoleId",
                table: "MovieCreators",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesCasts_Roles_RoleId",
                table: "MoviesCasts",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCreators_Roles_RoleId",
                table: "MovieCreators");

            migrationBuilder.DropForeignKey(
                name: "FK_MoviesCasts_Roles_RoleId",
                table: "MoviesCasts");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_MoviesCasts_RoleId",
                table: "MoviesCasts");

            migrationBuilder.DropIndex(
                name: "IX_MovieCreators_RoleId",
                table: "MovieCreators");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "MoviesCasts");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "MovieCreators");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Creators",
                type: "int",
                nullable: true);
        }
    }
}
