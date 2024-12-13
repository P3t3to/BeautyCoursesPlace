using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautyCoursesPlace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SaloonaddedUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Saloons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cea3db77-0dd1-4d38-892b-ac782d6ad953", "AQAAAAIAAYagAAAAEMO6HHJTmbH1NfnXJARW4Y9cxC0upMH9E0FaQKkO//1iOz8FdUCE9rZX3FTfSKcbAg==", "28204033-3922-40dc-b674-74f301040dfd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cc7a0b3d-02fc-468e-ad0c-3b4c79dcd53a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69028920-5a3b-4ad6-9969-0e6a8ad18b36", "AQAAAAIAAYagAAAAEOxmPjaNyrfKxaaiVNGSn9pdhfjTEPta9yTYI0icV3GdmDC8D9S3tfa30QsLzPbC8A==", "9033b5fd-fea1-4d8f-9c63-1242d6f85b4d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cea67c02-8a10-4929-9e4e-9337d6dad62e", "AQAAAAIAAYagAAAAEPK0R2oC65eA6Clf9Oz65gCkLlKG42xcESqz1Uq8+fF9kJZevIhZO8hVrdeutoSIYw==", "cd40e727-8104-41ad-8ddb-c0d275b2c9ef" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Saloons");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a8c3db8-cc75-4d6e-ba26-eb41f398ffa9", "AQAAAAIAAYagAAAAEPaqqZfJhVPUlFDubBxIsKGP0I2QyEyG+z7Mh82tb+C6IJsAb0BHE/lgHWS0JYuCYA==", "ddca7d36-8d42-496b-9ee7-e07c635d8718" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cc7a0b3d-02fc-468e-ad0c-3b4c79dcd53a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8fff0d19-f5f5-443b-937c-7dbf56f3e86a", "AQAAAAIAAYagAAAAEJUF67S4OImQBtpjnlLtzN64j1M1ciGJxi4x7xreUKT6WkDLZeUF/i9ZYC7DnCsZtQ==", "eb8215d9-88ac-437e-a5fb-145998afb355" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89d1b685-d572-4d63-ad5d-467baa9bb9b9", "AQAAAAIAAYagAAAAENpuF5gkbCqbOx17ujyflggkHgDHOJTL8fFLX+oqo4s9UUbSCfqms0GKkRDUpwM15g==", "3987f70d-0869-47a6-86ae-f46e83ba5f79" });
        }
    }
}
