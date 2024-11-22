using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeautyCoursesPlace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FistTablesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Category Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Category name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                },
                comment: "Course category");

            migrationBuilder.CreateTable(
                name: "Lectors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Lector Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Telephone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Lector phone number"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lectors_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Lector");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Course Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Course title"),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Course address"),
                    Description = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false, comment: "Course description"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Course image"),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Course cost"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Category Identifier"),
                    LectorId = table.Column<int>(type: "int", nullable: false, comment: "Lector Identifier"),
                    StudentId = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Identifier for student")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_Lectors_LectorId",
                        column: x => x.LectorId,
                        principalTable: "Lectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Courses to display");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_LectorId",
                table: "Courses",
                column: "LectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectors_UserId",
                table: "Lectors",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Lectors");
        }
    }
}
