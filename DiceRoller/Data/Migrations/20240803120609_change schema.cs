using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiceRoller.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeschema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StateLabels",
                table: "ProbabilityObjectModel");

            migrationBuilder.DropColumn(
                name: "StateProbabilities",
                table: "ProbabilityObjectModel");

            migrationBuilder.DropColumn(
                name: "StateViews",
                table: "ProbabilityObjectModel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StateLabels",
                table: "ProbabilityObjectModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StateProbabilities",
                table: "ProbabilityObjectModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StateViews",
                table: "ProbabilityObjectModel",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
