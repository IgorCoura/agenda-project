using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agenda.Infrastructure.Migrations
{
    public partial class createIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Phones_Id",
                table: "Phones");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_Id",
                table: "Contacts");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_DDD",
                table: "Phones",
                column: "DDD",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Phones_Number",
                table: "Phones",
                column: "Number",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Phones_DDD",
                table: "Phones");

            migrationBuilder.DropIndex(
                name: "IX_Phones_Number",
                table: "Phones");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_Id",
                table: "Phones",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Id",
                table: "Contacts",
                column: "Id");
        }
    }
}
