using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "organization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    NIP = table.Column<string>(type: "TEXT", nullable: false),
                    REGON = table.Column<string>(type: "TEXT", nullable: false),
                    Address_City = table.Column<string>(type: "TEXT", nullable: false),
                    Address_Street = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    birth = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OrganizationId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contacts_organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "organization",
                columns: new[] { "Id", "Address_City", "Address_Street", "NIP", "Name", "REGON" },
                values: new object[,]
                {
                    { 101, "Kraków", "św. Filipa 17", "68243654983", "WSEI", "6725725725" },
                    { 102, "Warszawa", "św. Jana 16", "972570370923", "UEK", "5325632570937" }
                });

            migrationBuilder.InsertData(
                table: "contacts",
                columns: new[] { "Id", "birth", "Created", "Email", "FirstName", "LastName", "OrganizationId", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, new DateOnly(2000, 10, 10), new DateTime(2024, 11, 12, 18, 27, 12, 767, DateTimeKind.Local).AddTicks(6821), "barti@gmail.com", "Bartek", "Kasperek", 101, "888111888" },
                    { 2, new DateOnly(2001, 11, 11), new DateTime(2024, 11, 12, 18, 27, 12, 767, DateTimeKind.Local).AddTicks(6866), "norbi@gmail.com", "Norbert", "Kasperek", 102, "111999111" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_contacts_OrganizationId",
                table: "contacts",
                column: "OrganizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.DropTable(
                name: "organization");
        }
    }
}
