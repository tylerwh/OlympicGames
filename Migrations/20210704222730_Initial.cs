using Microsoft.EntityFrameworkCore.Migrations;

namespace OlympicGames.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameID);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    GameID = table.Column<int>(nullable: true),
                    CategoryID = table.Column<int>(nullable: true),
                    FlagImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamID);
                    table.ForeignKey(
                        name: "FK_Teams_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[,]
                {
                    { 1, "Indoor" },
                    { 2, "Outdoor" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameID", "Name" },
                values: new object[,]
                {
                    { 1, "Summer Olympics" },
                    { 2, "Winter Olympics" },
                    { 3, "Paralympic Games" },
                    { 4, "Youth Olympics" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamID", "CategoryID", "FlagImage", "GameID", "Name" },
                values: new object[,]
                {
                    { "brz", 2, "BRZ.gif", 1, "Brazil" },
                    { "por", 2, "POR.png", 4, "Portugal" },
                    { "fra", 1, "FRA.gif", 4, "France" },
                    { "fin", 2, "FIN.jpg", 4, "Finland" },
                    { "cyp", 1, "CYP.gif", 4, "Cyprus" },
                    { "zim", 2, "ZIM.gif", 3, "Zimbabwe" },
                    { "uru", 1, "URU.png", 3, "Uruguay" },
                    { "ukr", 1, "UKR.jpg", 3, "Ukraine" },
                    { "thi", 1, "THI.png", 3, "Thailand" },
                    { "pak", 2, "PAK.png", 3, "Pakistan" },
                    { "aus", 2, "AUS.png", 3, "Austria" },
                    { "swe", 1, "SWE.jpg", 2, "Sweden" },
                    { "jap", 2, "JAP.gif", 2, "Japan" },
                    { "jam", 2, "JAM.gif", 2, "Jamaica" },
                    { "ita", 2, "ITA.gif", 2, "Italy" },
                    { "gbr", 1, "GBR.jpg", 2, "Great Britain" },
                    { "can", 1, "CAN.png", 2, "Canada" },
                    { "usa", 2, "USA.png", 1, "USA" },
                    { "net", 2, "NET.png", 1, "Netherlands" },
                    { "mex", 1, "MEX.png", 1, "Mexico" },
                    { "ger", 1, "GER.gif", 1, "Germany" },
                    { "chn", 1, "CHN.gif", 1, "China" },
                    { "rus", 1, "RUS.png", 4, "Russia" },
                    { "slo", 2, "SLO.jpg", 4, "Slovakia" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CategoryID",
                table: "Teams",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_GameID",
                table: "Teams",
                column: "GameID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
