using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentProject.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Credit = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Credit", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note" },
                values: new object[,]
                {
                    { 1, "Admin", new DateTime(2022, 9, 29, 4, 32, 21, 211, DateTimeKind.Local).AddTicks(6460), 6, true, false, "Admin", new DateTime(2022, 9, 29, 4, 32, 21, 212, DateTimeKind.Local).AddTicks(2802), "Matematik", "default" },
                    { 2, "Admin", new DateTime(2022, 9, 29, 4, 32, 21, 212, DateTimeKind.Local).AddTicks(3756), 5, true, false, "Admin", new DateTime(2022, 9, 29, 4, 32, 21, 212, DateTimeKind.Local).AddTicks(3760), "Fizik 1", "default" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "Lastname", "ModifiedByName", "ModifiedDate", "Name", "Note", "Number" },
                values: new object[,]
                {
                    { 1, "Admin", new DateTime(2022, 9, 29, 4, 32, 21, 214, DateTimeKind.Local).AddTicks(6087), true, false, "Çiftçi", "Admin", new DateTime(2022, 9, 29, 4, 32, 21, 214, DateTimeKind.Local).AddTicks(6093), "Ahmet", "default", "211213100" },
                    { 2, "Admin", new DateTime(2022, 9, 29, 4, 32, 21, 214, DateTimeKind.Local).AddTicks(6906), true, false, "Göksu", "Admin", new DateTime(2022, 9, 29, 4, 32, 21, 214, DateTimeKind.Local).AddTicks(6910), "Mehmet", "default", "212705001" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
