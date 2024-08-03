using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiceRoller.Data.Migrations
{
    /// <inheritdoc />
    public partial class Setupdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProbabilityObjectModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfStates = table.Column<int>(type: "int", nullable: false),
                    StateLabels = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateProbabilities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateViews = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProbabilityObjectModel", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProbabilityObjectModel");
        }
    }
}
