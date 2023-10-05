using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BattleShipLibrary.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameDataModelsDb",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Player1Board = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Player1HitBoard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Player2Board = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Player2HitBoard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Player1Points = table.Column<int>(type: "int", nullable: false),
                    Player2Points = table.Column<int>(type: "int", nullable: false),
                    GamePoints = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameDataModelsDb", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameDataModelsDb");
        }
    }
}
