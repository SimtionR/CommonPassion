using Microsoft.EntityFrameworkCore.Migrations;

namespace CommonPassion_Backend.Migrations
{
    public partial class ChangeLeagues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserReviews_Leagues_LeagueReviewdId",
                table: "UserReviews");

            migrationBuilder.DropTable(
                name: "Leagues");

            migrationBuilder.CreateTable(
                name: "LeagueDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeagueId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeagueDetails", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserReviews_LeagueDetails_LeagueReviewdId",
                table: "UserReviews",
                column: "LeagueReviewdId",
                principalTable: "LeagueDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserReviews_LeagueDetails_LeagueReviewdId",
                table: "UserReviews");

            migrationBuilder.DropTable(
                name: "LeagueDetails");

            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserReviews_Leagues_LeagueReviewdId",
                table: "UserReviews",
                column: "LeagueReviewdId",
                principalTable: "Leagues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
