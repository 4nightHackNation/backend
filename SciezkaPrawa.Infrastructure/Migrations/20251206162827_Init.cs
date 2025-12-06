using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SciezkaPrawa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Summary = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    Priority = table.Column<string>(type: "TEXT", nullable: false),
                    Urgency = table.Column<string>(type: "TEXT", nullable: false),
                    Committee = table.Column<string>(type: "TEXT", nullable: true),
                    Sponsor = table.Column<string>(type: "TEXT", nullable: true),
                    DateSubmitted = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HasConsultation = table.Column<bool>(type: "INTEGER", nullable: false),
                    ConsultationStart = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ConsultationEnd = table.Column<DateTime>(type: "TEXT", nullable: true),
                    AmendmentsCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActReadingVotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ActId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReadingName = table.Column<string>(type: "TEXT", nullable: false),
                    For = table.Column<int>(type: "INTEGER", nullable: false),
                    Against = table.Column<int>(type: "INTEGER", nullable: false),
                    Abstain = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActReadingVotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActReadingVotes_Acts_ActId",
                        column: x => x.ActId,
                        principalTable: "Acts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActStages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ActId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActStages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActStages_Acts_ActId",
                        column: x => x.ActId,
                        principalTable: "Acts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActVersion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ActId = table.Column<Guid>(type: "TEXT", nullable: false),
                    VersionNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    FilePath = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActVersion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActVersion_Acts_ActId",
                        column: x => x.ActId,
                        principalTable: "Acts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActTags",
                columns: table => new
                {
                    ActId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TagId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActTags", x => new { x.ActId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ActTags_Acts_ActId",
                        column: x => x.ActId,
                        principalTable: "Acts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActReadingVotes_ActId",
                table: "ActReadingVotes",
                column: "ActId");

            migrationBuilder.CreateIndex(
                name: "IX_ActStages_ActId",
                table: "ActStages",
                column: "ActId");

            migrationBuilder.CreateIndex(
                name: "IX_ActTags_TagId",
                table: "ActTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_ActVersion_ActId",
                table: "ActVersion",
                column: "ActId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActReadingVotes");

            migrationBuilder.DropTable(
                name: "ActStages");

            migrationBuilder.DropTable(
                name: "ActTags");

            migrationBuilder.DropTable(
                name: "ActVersion");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Acts");
        }
    }
}
