using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautyCoursesPlace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RewiewsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Feedback = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "398ff79d-a6d2-482f-9fc2-18b6b3d398cc", "AQAAAAIAAYagAAAAEFu1FyHpfh3XJGL3XPXfNI6vXjb0K7/xt1hRlT4ECTRCy79PYstmVPDUddz2+fee2Q==", "e42c41dd-ef52-4bbd-b024-717f4e1ecbfe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cc7a0b3d-02fc-468e-ad0c-3b4c79dcd53a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39ac6642-24f8-4613-9f57-f55d4bc42e65", "AQAAAAIAAYagAAAAECKCZHAkMbo8UqqVm5l8bupOoXiKn74BSlBA64VUJlo5Z6/X2ZW3aRXDGsYJke6p8Q==", "24297dd3-84f7-4b5c-bfc7-3b04dae6a2ab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b09f3444-7997-47ce-90d4-0f499d511a5e", "AQAAAAIAAYagAAAAEC8bAHdTNRMb7ojgaXCHtw1YkpV774DpIBxZnKxDEunsqP52vS0TL3G5kOW7aB/KvQ==", "e1f13149-8d40-4478-b0bb-696bf310029e" });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CourseId",
                table: "Reviews",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

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
    }
}
