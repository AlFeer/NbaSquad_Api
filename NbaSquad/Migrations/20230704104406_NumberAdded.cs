using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NbaSquad.Migrations
{
    /// <inheritdoc />
    public partial class NumberAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Players",
                newName: "Number");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Players",
                newName: "Age");
        }
    }
}
