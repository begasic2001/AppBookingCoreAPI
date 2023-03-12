using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnAPI.Migrations
{
    /// <inheritdoc />
    public partial class ReUpdatetour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToursCities_City_CityId",
                table: "ToursCities");

            migrationBuilder.DropForeignKey(
                name: "FK_ToursCities_Tour_TourId",
                table: "ToursCities");

            migrationBuilder.AddForeignKey(
                name: "FK_ToursCities_City_CityId",
                table: "ToursCities",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ToursCities_Tour_TourId",
                table: "ToursCities",
                column: "TourId",
                principalTable: "Tour",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToursCities_City_CityId",
                table: "ToursCities");

            migrationBuilder.DropForeignKey(
                name: "FK_ToursCities_Tour_TourId",
                table: "ToursCities");

            migrationBuilder.AddForeignKey(
                name: "FK_ToursCities_City_CityId",
                table: "ToursCities",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ToursCities_Tour_TourId",
                table: "ToursCities",
                column: "TourId",
                principalTable: "Tour",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
