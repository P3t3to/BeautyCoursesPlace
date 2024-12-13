using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautyCoursesPlace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Partneruserid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Partners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.UpdateData(
                table: "Partners",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "");

            migrationBuilder.UpdateData(
                table: "Partners",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Partners");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b943b38-5f78-48a6-b2bf-2210124e8f37", "AQAAAAIAAYagAAAAEAES/g/amol1CLxv7KJmRJ4v47wskwtdOUOTiA2ISaNGbIhSdelS+WYrfNSTfE/8Wg==", "94c3693d-acf6-4a25-879c-4742e325e3d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cc7a0b3d-02fc-468e-ad0c-3b4c79dcd53a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a4d46673-3df2-4c37-8371-27e0839a9df1", "AQAAAAIAAYagAAAAEPjMv1pDEnlwQqv3ra7g1oxWgTpawnZt2tHnKl/1qqrZXdBr2rfvnvGrRVbCO0IZiQ==", "9ab33b1a-02cd-4916-8588-1b357f5d352f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4517f6e7-0cc6-4ab4-8d4a-6279cb1d8048", "AQAAAAIAAYagAAAAEJJoWYPJ0tUzKG40Qa/i6F1TCJmPRX/ZRol4hTLkdN8cNearMpimMDdm4jkh/KKGlQ==", "a7a4c665-ce1c-43b1-bcc6-38831cde37b7" });
        }
    }
}
