using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautyCoursesPlace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PhoneNumberUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Lectors_Telephone",
                table: "Lectors",
                column: "Telephone",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Lectors_Telephone",
                table: "Lectors");

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
        }
    }
}
