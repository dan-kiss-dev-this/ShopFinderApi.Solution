using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopFinderApi.Migrations
{
    public partial class RestaurantSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "RestaurantId", "Description", "Rating", "TypeOfFood" },
                values: new object[] { 1, "La Bella", 5, "Italian" });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "RestaurantId", "Description", "Rating", "TypeOfFood" },
                values: new object[] { 2, "CurryHouse", 4, "Indian" });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "RestaurantId", "Description", "Rating", "TypeOfFood" },
                values: new object[] { 3, "Ye Old Fish and Chip", 4, "English" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 3);
        }
    }
}
