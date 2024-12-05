using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautyCoursesPlace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Admin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ab3fd33-2ffa-4853-942e-f6038f9c48b6", "AQAAAAIAAYagAAAAEKkS1H3dOfIW2sQSC0kJ7TZjLsOx+IDFWeaoI/YoOpS5cCCZQxeYcIf6nGP8aYf59A==", "801f6cd8-afe9-46f0-b99c-b595116e5c00" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ecaa44d-662e-403d-a62a-c275b5096337", "AQAAAAIAAYagAAAAEAa15FedqQJvkUXqW2KjuwUgMwWduhVK4PT7bQqFZ3lXBQK/QhNnZHU46wZpuVHnJQ==", "6a1c56d1-cb09-40e8-8489-8b28d4937671" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cc7a0b3d-02fc-468e-ad0c-3b4c79dcd53a", 0, "77fae0a8-da5a-417e-a4f1-839677ce11b0", "admin@mail.com", false, "Viktoria", "Deyanska Great Admin", false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", null, null, false, "0e4c0a31-e8a0-4bf1-8d85-9d31b8e4856b", false, "admint@mail.com" });

            migrationBuilder.InsertData(
                table: "Lectors",
                columns: new[] { "Id", "Telephone", "UserId" },
                values: new object[] { 5, "+359899987654", "cc7a0b3d-02fc-468e-ad0c-3b4c79dcd53a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lectors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cc7a0b3d-02fc-468e-ad0c-3b4c79dcd53a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "817ab22a-f620-4d43-865a-127466f82697", "AQAAAAIAAYagAAAAEOwc8cQYNgeDKval6Gsr7Gyd38nmNNJfVrPcJ+LyDwmIEbhs1qatgSGrM4ZVw4njhg==", "0d9a101d-d547-4940-a132-ff0c4f0983d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d48149b9-34e3-4f0b-a8cf-0b278bb78bcd", "AQAAAAIAAYagAAAAENa6YZ1SREIsBNATldMi4S1SE4I8o3BUCVW0irzj1AhabTlmwJWKkmWzu7wN4VtqKA==", "5aa849c2-2dd1-47c8-97c7-d9d182d3bf41" });
        }
    }
}
