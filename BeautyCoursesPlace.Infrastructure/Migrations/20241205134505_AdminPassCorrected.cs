using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautyCoursesPlace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdminPassCorrected : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: "cc7a0b3d-02fc-468e-ad0c-3b4c79dcd53a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77fae0a8-da5a-417e-a4f1-839677ce11b0", null, "0e4c0a31-e8a0-4bf1-8d85-9d31b8e4856b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ecaa44d-662e-403d-a62a-c275b5096337", "AQAAAAIAAYagAAAAEAa15FedqQJvkUXqW2KjuwUgMwWduhVK4PT7bQqFZ3lXBQK/QhNnZHU46wZpuVHnJQ==", "6a1c56d1-cb09-40e8-8489-8b28d4937671" });
        }
    }
}
