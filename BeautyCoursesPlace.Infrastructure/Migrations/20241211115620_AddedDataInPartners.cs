using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautyCoursesPlace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedDataInPartners : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
