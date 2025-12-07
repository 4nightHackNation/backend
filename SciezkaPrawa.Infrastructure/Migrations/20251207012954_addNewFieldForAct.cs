using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SciezkaPrawa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addNewFieldForAct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlainLanguageSummary",
                table: "Acts",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlainLanguageSummary",
                table: "Acts");
        }
    }
}
