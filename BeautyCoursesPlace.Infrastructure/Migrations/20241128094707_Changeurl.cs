using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautyCoursesPlace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Changeurl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e90cb775-db6f-4a73-93dc-70efe9e65ca6", "AQAAAAIAAYagAAAAEHwW29pPtsnRetmChpCnNDnUOW3MkP84rPuoxPNnI22tU9ltIKTs3+ERKE2GPBzLbA==", "c6c2612c-2b8f-49d1-9657-0a7bf49b09fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9879ec8d-046e-4af2-b1a5-133e10b6a1bf", "AQAAAAIAAYagAAAAEJFroG3c1N19apj8XCwZIvRbRZWk3BYRN7Lk11xnqgFPnAAgm/cPGD0MsdHC7KzJng==", "f12c26d7-3d4b-4a48-abba-dd5c5eb07f39" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://artdeco.com/cdn/shop/files/Shop-the-Look-Schminktipp-Cut-Crease_V2-600x600_600x600.jpg?v=1684735658");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSY16nniu9WfRnBZisa1BKW5ss9sHlx2blUeg&s");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSE0LHapGysMlndotyOkN0h4T4RynF7P_xJEA&s");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eb04485b-0d6f-4f1f-9d39-e7c77ee71959", "AQAAAAIAAYagAAAAECVvmv0ojvxCoHC6itUV8lHeyArU8OCLC+x4WKgEuLJd1aH6Sd/RJyadhU0w2tyq8w==", "35c37a28-3b22-4e18-96ac-92aa75e020bd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d1d493a-5bea-4813-b430-09c67d2b01d8", "AQAAAAIAAYagAAAAECSy6KtqmcP1tPdXSD7AHKiue2Q92A4rmvhcYcDAbcAHY3htADXeR5z38rlFJLuUQA==", "bf3625d1-15f7-4bdb-885b-394f9315de19" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://www.pinterest.com/pin/hair-makeup-nails--258957047313127874/");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://www.shutterstock.com/image-photo/stylist-using-hair-brush-dryer-bright-2442221183");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://www.gettyimages.com/detail/photo/young-woman-painting-fingernails-close-up-royalty-free-image/DA20814?adppopup=true");
        }
    }
}
