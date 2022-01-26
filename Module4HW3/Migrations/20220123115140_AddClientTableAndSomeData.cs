using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Module4HW3.Migrations
{
    public partial class AddClientTableAndSomeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "DateOfBirth", "FirstName", "LastName", "MiddleName" },
                values: new object[,]
                {
                    { 1, null, "Eliza", "Warren", "Louise" },
                    { 2, null, "Eliza2", "Warren2", "Louise2" },
                    { 3, null, "Eliza3", "Warren3", "Louise3" },
                    { 4, null, "Eliza", "Warren", "Louise" },
                    { 5, null, "Eliza5", "Warren5", "Louise5" }
                });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectId", "Budget", "ClientId", "Name", "StartedDate" },
                values: new object[,]
                {
                    { 1, 2000m, 1, "PName1", new DateTime(2022, 1, 23, 11, 51, 39, 568, DateTimeKind.Utc).AddTicks(6339) },
                    { 5, 1000m, 1, "PName5", new DateTime(2022, 1, 23, 11, 51, 39, 568, DateTimeKind.Utc).AddTicks(7120) },
                    { 2, 100m, 2, "PName2", new DateTime(2022, 1, 23, 11, 51, 39, 568, DateTimeKind.Utc).AddTicks(7113) },
                    { 4, 8000m, 2, "PName4", new DateTime(2022, 1, 23, 11, 51, 39, 568, DateTimeKind.Utc).AddTicks(7118) },
                    { 3, 5000m, 3, "PName3", new DateTime(2022, 1, 23, 11, 51, 39, 568, DateTimeKind.Utc).AddTicks(7117) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_ClientId",
                table: "Project",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Clients_ClientId",
                table: "Project",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Clients_ClientId",
                table: "Project");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Project_ClientId",
                table: "Project");

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Project");
        }
    }
}
