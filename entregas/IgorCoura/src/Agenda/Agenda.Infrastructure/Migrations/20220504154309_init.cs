using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agenda.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FormattedPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DDD = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", maxLength: 9, nullable: false),
                    PhoneTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phones_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Phones_PhoneTypes_PhoneTypeId",
                        column: x => x.PhoneTypeId,
                        principalTable: "PhoneTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "PhoneTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Residencial" });

            migrationBuilder.InsertData(
                table: "PhoneTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Cellphone" });

            migrationBuilder.InsertData(
                table: "PhoneTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Commercial" });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Id",
                table: "Contacts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_ContactId",
                table: "Phones",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_Id",
                table: "Phones",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_PhoneTypeId",
                table: "Phones",
                column: "PhoneTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "PhoneTypes");
        }
    }
}
