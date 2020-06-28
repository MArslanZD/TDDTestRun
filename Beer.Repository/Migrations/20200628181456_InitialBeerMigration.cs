using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Beer.Repository.Migrations
{
    public partial class InitialBeerMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beers",
                columns: table => new
                {
                    BeerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beers", x => x.BeerId);
                });

            migrationBuilder.InsertData(
                table: "Beers",
                columns: new[] { "BeerId", "Name", "Type" },
                values: new object[] { 1, "Sample Beer 1", "Pale Ale" });

            migrationBuilder.InsertData(
                table: "Beers",
                columns: new[] { "BeerId", "Name", "Type" },
                values: new object[] { 2, "Sample Beer 2", "Stout" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beers");
        }
    }
}
