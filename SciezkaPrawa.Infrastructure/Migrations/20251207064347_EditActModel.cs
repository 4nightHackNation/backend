using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SciezkaPrawa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditActModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FollowedActId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Committee",
                table: "Acts");

            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Acts");

            migrationBuilder.DropColumn(
                name: "Urgency",
                table: "Acts");

            migrationBuilder.RenameColumn(
                name: "AmendmentsCount",
                table: "Acts",
                newName: "Kadencja");

            migrationBuilder.AddColumn<int>(
                name: "CurrentStage",
                table: "Acts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserFollowedActs",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ActId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFollowedActs", x => new { x.UserId, x.ActId });
                    table.ForeignKey(
                        name: "FK_UserFollowedActs_Acts_ActId",
                        column: x => x.ActId,
                        principalTable: "Acts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFollowedActs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFollowedActs_ActId",
                table: "UserFollowedActs",
                column: "ActId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFollowedActs");

            migrationBuilder.DropColumn(
                name: "CurrentStage",
                table: "Acts");

            migrationBuilder.RenameColumn(
                name: "Kadencja",
                table: "Acts",
                newName: "AmendmentsCount");

            migrationBuilder.AddColumn<Guid>(
                name: "FollowedActId",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Committee",
                table: "Acts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Acts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Urgency",
                table: "Acts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
