using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace com.b_velop.coffee_O_mat.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brews",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Temperature = table.Column<double>(nullable: false),
                    TargetTemperature = table.Column<double>(nullable: false),
                    Output = table.Column<double>(nullable: false),
                    KP = table.Column<double>(nullable: false),
                    KI = table.Column<double>(nullable: false),
                    KD = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brews", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brews");
        }
    }
}
