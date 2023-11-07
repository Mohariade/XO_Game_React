using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business_And_Data_Layers.Migrations
{
    /// <inheritdoc />
    public partial class CreateTheDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Game_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Player1_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Player2_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerTurn_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Board = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Game_Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
