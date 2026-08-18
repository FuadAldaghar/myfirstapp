using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFirstApp.Migrations
{
    public partial class SeedProjectData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "WEB DEVELOPMENT" },
                    { 2, "DESKTOP DEVELOPMENT" },
                    { 3, "MOBILE DEVELOPMENT" },
                    { 4, "ARTIFICIAL INTELLIGENCE" }
                });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "C#" },
                    { 2, "ASP.NET CORE" },
                    { 3, "MYSQL" },
                    { 4, "JAVASCRIPT" },
                    { 5, "PYTHON" },
                    { 6, "FLUTTER" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CategoryId", "Description", "GitHubUrl", "IsPublic", "License", "Name", "ProjectType", "TechnologiesCount" },
                values: new object[,]
                {
                    { 1, 1, "ASP.NET CORE MVC PROJECT", "https://github.com/example/my-first-app", true, "MIT", "MY FIRST APP", "WEB", 0 },
                    { 2, 1, "NOTE MANAGEMENT APPLICATION", "https://github.com/example/notes-app", true, "MIT", "NOTES APP", "WEB", 0 },
                    { 3, 4, "AI BASED SMART SYSTEM", "https://github.com/example/smart-system", true, "MIT", "SMART SYSTEM", "AI", 0 },
                    { 4, 3, "CROSS PLATFORM MOBILE APPLICATION", "https://github.com/example/mobile-app", false, "MIT", "MOBILE APP", "MOBILE", 0 }
                });

            migrationBuilder.InsertData(
                table: "ProjectDetails",
                columns: new[] { "Id", "Budget", "Client", "EndDate", "ProjectId", "StartDate" },
                values: new object[,]
                {
                    { 1, 1000m, "CLIENT A", new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1500m, "CLIENT B", new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3000m, "CLIENT C", new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2000m, "CLIENT D", new DateTime(2026, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ProjectTechnology",
                columns: new[] { "ProjectsId", "TechnologiesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 3, 5 },
                    { 4, 4 },
                    { 4, 6 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProjectDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProjectDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProjectDetails",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProjectDetails",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProjectTechnology",
                keyColumns: new[] { "ProjectsId", "TechnologiesId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProjectTechnology",
                keyColumns: new[] { "ProjectsId", "TechnologiesId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectTechnology",
                keyColumns: new[] { "ProjectsId", "TechnologiesId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectTechnology",
                keyColumns: new[] { "ProjectsId", "TechnologiesId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ProjectTechnology",
                keyColumns: new[] { "ProjectsId", "TechnologiesId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectTechnology",
                keyColumns: new[] { "ProjectsId", "TechnologiesId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectTechnology",
                keyColumns: new[] { "ProjectsId", "TechnologiesId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectTechnology",
                keyColumns: new[] { "ProjectsId", "TechnologiesId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "ProjectTechnology",
                keyColumns: new[] { "ProjectsId", "TechnologiesId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "ProjectTechnology",
                keyColumns: new[] { "ProjectsId", "TechnologiesId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
