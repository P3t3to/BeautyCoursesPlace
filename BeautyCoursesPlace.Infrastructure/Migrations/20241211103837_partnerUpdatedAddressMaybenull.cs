using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautyCoursesPlace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class partnerUpdatedAddressMaybenull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Partners",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "Partner address",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldComment: "Partner address");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3fa93cce-e30e-4919-8449-8173ed741204", "AQAAAAIAAYagAAAAECO2kyJ3XZkQ48PUae8nwd5viDDhYufnmVTOjCx3ByOjDHXwFd8wlHL9uDOHKs1h0Q==", "2d871a46-d2f5-4e8b-afb7-60e5cd64734c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cc7a0b3d-02fc-468e-ad0c-3b4c79dcd53a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc5f1d52-a8a0-4db5-998a-9df7f8e6ab91", "AQAAAAIAAYagAAAAEBDwOpBf647LFYECor3CB94Yt0Da4FCfhdlZuhQnSFe+7AnF+vuHs7WYPDtzWaWzHQ==", "826e8cc8-c940-4598-b572-6299840313ee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9828fed1-31fe-4e35-b9c6-5386b8a67c73", "AQAAAAIAAYagAAAAEB3+lpmAtKKg9dVGq+zPhyi3FnRqEMYlvXu3AjD+xtTvVrHurrR/hVy1PsKPtytFcw==", "6c2f0400-c89d-48aa-9ad3-98b1a72ad726" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Partners",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                comment: "Partner address",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true,
                oldComment: "Partner address");

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
    }
}
