using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautyCoursesPlace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class partnerUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Partners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Partner logo or image URL");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10e82c79-f3c2-4687-8a2a-37c05a79f819", "AQAAAAIAAYagAAAAEIsPFT0rBp3v2pX+IGlspx09Ye9rpiC5wOO23dh6KsZ2gZN4tgWHDB2kztT7TiavVg==", "407b0cf7-4acd-4b12-b36d-4a8d62b77cc8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cc7a0b3d-02fc-468e-ad0c-3b4c79dcd53a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b19671b-60e0-42d1-b5d5-a46b50fb0dba", "AQAAAAIAAYagAAAAEGOfwmUFxjrAnVRMex6dkZiwPCJve4Q/dvIvS0rxmnjuZI3DSy4RU1uNcDhYSStOWA==", "48cda78d-4977-4135-993b-43dcd2b24327" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3e9ccfc-408d-4adb-9edb-f30e06189ec4", "AQAAAAIAAYagAAAAEKXnxcjavhwMxi9rYXHMZgf+zJ6RGF2lYaYs+iXiT9pA/kiDQSZQc3+HzgDUZLrN+Q==", "3fb4b63e-393d-4eec-b5fc-15414fa5de1d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Partners");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f16bb6e-e299-4270-974b-1f936e394d58", "AQAAAAIAAYagAAAAEL73OhZc7lb/8n6VRLBTuDly+FNXZ7POX5zf/JCDDFYebrvzGkKTBTaWalRHuHETGw==", "30ea465a-e62a-41d3-98c7-9e712f94ff16" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cc7a0b3d-02fc-468e-ad0c-3b4c79dcd53a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "678308cc-d2ec-40b2-9230-380fa18a664d", "AQAAAAIAAYagAAAAEFzTog5NgaML0gZL+7vgmCAxgGGEAyNi5KJPSsqCwNQ8BF2o4txfpEdariI9jGOVgg==", "6244cc47-9ad8-40e9-82ae-446295966689" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "813b02cf-781d-4bad-b4f7-d4cc4c774752", "AQAAAAIAAYagAAAAENDbw3FakbXpMGQg/PVvaG2Wu9Dap38zkF7JnrVt9qy77bkMff2XLe+ocq5ZRH8oFw==", "c59f90f7-69e8-44b4-919e-a734a8568053" });
        }
    }
}
