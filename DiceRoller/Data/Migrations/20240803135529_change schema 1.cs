using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiceRoller.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeschema1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "ProbabilityObjectModel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "ProbabilityObjectModel");
        }
    }
}
