using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyCoursesPlace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DataSeedandPartnerIdNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Partners_PartnerId",
                table: "Courses");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Courses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Course title",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldComment: "Course title");

            migrationBuilder.AlterColumn<int>(
                name: "PartnerId",
                table: "Courses",
                type: "int",
                nullable: true,
                comment: "Identifier for partner",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Identifier for partner");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "eb04485b-0d6f-4f1f-9d39-e7c77ee71959", "guest@mail.com", false, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAIAAYagAAAAECVvmv0ojvxCoHC6itUV8lHeyArU8OCLC+x4WKgEuLJd1aH6Sd/RJyadhU0w2tyq8w==", null, false, "35c37a28-3b22-4e18-96ac-92aa75e020bd", false, "guest@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "8d1d493a-5bea-4813-b430-09c67d2b01d8", "agent@mail.com", false, false, null, "agent@mail.com", "agent@mail.com", "AQAAAAIAAYagAAAAECSy6KtqmcP1tPdXSD7AHKiue2Q92A4rmvhcYcDAbcAHY3htADXeR5z38rlFJLuUQA==", null, false, "bf3625d1-15f7-4bdb-885b-394f9315de19", false, "agent@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Makeup" },
                    { 2, "Hair" },
                    { 3, "Nails" }
                });

            migrationBuilder.InsertData(
                table: "Lectors",
                columns: new[] { "Id", "Telephone", "UserId" },
                values: new object[] { 1, "+359888888888", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Address", "CategoryId", "Cost", "Description", "ImageUrl", "LectorId", "PartnerId", "StudentId", "Title" },
                values: new object[,]
                {
                    { 1, "17 Lydford Rd London UK", 1, 700.00m, "If you want to learn how to do Half cut crease and create this makeup look, join the course.", "https://www.pinterest.com/pin/hair-makeup-nails--258957047313127874/", 1, null, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", "Cut crease tehnique" },
                    { 2, "  77 Sidmouth Rd London, England", 2, 400.00m, "This course covers several methods for professionally blow-drying, curling, trimming, and colouring hair.", "https://www.shutterstock.com/image-photo/stylist-using-hair-brush-dryer-bright-2442221183", 1, null, null, "Hair Styling: Blow-Dry, Cut, and Colour Like a Pro" },
                    { 3, "290 Willesden Lane London, England", 3, 2000.00m, "Learn how to care for nails like a pro and perform treatments like manicures and pedicures in this free online course.", "https://www.gettyimages.com/detail/photo/young-woman-painting-fingernails-close-up-royalty-free-image/DA20814?adppopup=true", 1, null, null, "Nail Care and Treatment " }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Partners_PartnerId",
                table: "Courses",
                column: "PartnerId",
                principalTable: "Partners",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Partners_PartnerId",
                table: "Courses");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Lectors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Courses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                comment: "Course title",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Course title");

            migrationBuilder.AlterColumn<int>(
                name: "PartnerId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Identifier for partner",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Identifier for partner");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Partners_PartnerId",
                table: "Courses",
                column: "PartnerId",
                principalTable: "Partners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
