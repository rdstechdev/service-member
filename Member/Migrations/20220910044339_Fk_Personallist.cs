using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Member.Migrations
{
    public partial class Fk_Personallist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MEMBERLIST_IDPERSONAL",
                table: "MEMBERLIST",
                column: "IDPERSONAL");

            migrationBuilder.AddForeignKey(
                name: "MEMBER_PERSON",
                table: "MEMBERLIST",
                column: "IDPERSONAL",
                principalTable: "PERSONALLIST",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "MEMBER_PERSON",
                table: "MEMBERLIST");

            migrationBuilder.DropIndex(
                name: "IX_MEMBERLIST_IDPERSONAL",
                table: "MEMBERLIST");
        }
    }
}
