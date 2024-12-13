using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyCoursesPlace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedDataInPartners2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Partners",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Partners",
                keyColumn: "Id",
                keyValue: -1);

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

            migrationBuilder.InsertData(
                table: "Partners",
                columns: new[] { "Id", "Address", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQNttQsOgRhhhzmKi-gAW23cj2VgGcayhsnkA&s", "BeautyPlace" },
                    { 2, "", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQa4puCFpPTXAjYJHIMCXEz1vUFuCj6LnwUKg&s", "HairByMaster" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Partners",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Partners",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "052a27fb-e572-4fc7-a0b0-ed9219ab650c", "AQAAAAIAAYagAAAAEKcaKotDf3iFdldjG+9h6EV6Fs9n9F7lWUkOLn+48e0saQHdkQnSPQo23IgbLRpYiQ==", "b7e55bee-f0df-4c29-a213-d1b27e70037f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cc7a0b3d-02fc-468e-ad0c-3b4c79dcd53a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f51af7b3-f42f-4685-8c96-753497f2f62a", "AQAAAAIAAYagAAAAEDUftJW8JvKfnOHke7nNnHYDSGwSSwACmoUJOb6KZa8kAvleTV7iDBr3YUqBjtQong==", "f1c568c9-5846-4755-8db9-a71fdb3ed14b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "568655bc-1213-441a-b7b6-ea74ecbc8425", "AQAAAAIAAYagAAAAEP6whhOUXD94jxVTBeFrfHJQ+Fv4mAXn/LHIoqDl9rleqZtcNrbMBGU5VKCjC/FkFQ==", "4dfb2460-c4c2-4475-80cd-4f8f5707f20a" });

            migrationBuilder.InsertData(
                table: "Partners",
                columns: new[] { "Id", "Address", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { -2, "", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQa4puCFpPTXAjYJHIMCXEz1vUFuCj6LnwUKg&s", "HairByMaster" },
                    { -1, "", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQNttQsOgRhhhzmKi-gAW23cj2VgGcayhsnkA&s", "BeautyPlace" }
                });
        }
    }
}
