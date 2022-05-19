using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelstarRoutePlanner.Data.Migrations
{
    public partial class AddedCityCarrierSegmentTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carriers",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carriers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Segments",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    City1ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    City2ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CarrierID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Segments_Carriers_CarrierID",
                        column: x => x.CarrierID,
                        principalTable: "Carriers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Segments_Cities_City1ID",
                        column: x => x.City1ID,
                        principalTable: "Cities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Segments_Cities_City2ID",
                        column: x => x.City2ID,
                        principalTable: "Cities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Segments_CarrierID",
                table: "Segments",
                column: "CarrierID");

            migrationBuilder.CreateIndex(
                name: "IX_Segments_City1ID",
                table: "Segments",
                column: "City1ID");

            migrationBuilder.CreateIndex(
                name: "IX_Segments_City2ID",
                table: "Segments",
                column: "City2ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Segments");

            migrationBuilder.DropTable(
                name: "Carriers");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
