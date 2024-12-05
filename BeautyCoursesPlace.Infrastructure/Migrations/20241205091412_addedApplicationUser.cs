using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautyCoursesPlace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "817ab22a-f620-4d43-865a-127466f82697", "", "", "AQAAAAIAAYagAAAAEOwc8cQYNgeDKval6Gsr7Gyd38nmNNJfVrPcJ+LyDwmIEbhs1qatgSGrM4ZVw4njhg==", "0d9a101d-d547-4940-a132-ff0c4f0983d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d48149b9-34e3-4f0b-a8cf-0b278bb78bcd", "", "", "AQAAAAIAAYagAAAAENa6YZ1SREIsBNATldMi4S1SE4I8o3BUCVW0irzj1AhabTlmwJWKkmWzu7wN4VtqKA==", "5aa849c2-2dd1-47c8-97c7-d9d182d3bf41" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5afeef15-b322-46ed-b491-214b3fb27d06", "AQAAAAIAAYagAAAAEL2gYmF4thFqjKKbp9qkMainyf4bEhvR8bQQ5DV4XK7FiQfJ1W8wto1OHL8uhBMPeA==", "047fe3e9-3c5f-4e51-b279-bfc757669ea4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b9e8af7-e681-4848-a22d-b347621c626d", "AQAAAAIAAYagAAAAEMrKx+jftC2xwwQ5m9KBTyXmUV74klNdfa2xBA8hp0f+ypl59Lefg06a3x/Tf3n7HA==", "9bb55425-0159-44c8-8799-d7046f1f3cb9" });
        }
    }
}
