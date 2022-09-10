using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Member.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MEMBERLIST",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPERSONAL = table.Column<long>(type: "bigint", nullable: true),
                    TOTALPREMIUM = table.Column<double>(type: "float", nullable: true),
                    ENTRYBY = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ENTRYDATE = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEMBERLIST", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PERSONALLIST",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    STARTDATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    ENTRYDATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    ENTRYBY = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSONALLIST", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MEMBERLIST");

            migrationBuilder.DropTable(
                name: "PERSONALLIST");
        }
    }
}
