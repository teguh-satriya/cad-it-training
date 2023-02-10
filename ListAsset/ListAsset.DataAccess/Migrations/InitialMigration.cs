using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ListAsset.DataAccess.Migrations
{
    public partial class InitialMigration:Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dbo.Countries",
                columns: table => new
                {
                    CountryId = table.Column<Guid>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "dbo.Assets",
                columns: table => new
                {
                    AssetId = table.Column<Guid>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssetCode = table.Column<string>(nullable: false),
                    AssetName = table.Column<string>(nullable: false),
                    AssetType = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false, defaultValue: 0),
                    CountryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.AssetId);
                    table.ForeignKey("FK_Assets_Country_Id", x => x.CountryId, "dbo.Assets");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dbo.Countries");
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Country_Id", table: "dbo.Assets");
            migrationBuilder.DropTable(
                name: "dbo.Assets");
        }
    }
}
