using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OiPubAssignment.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Paper",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    paperauthor = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    datapublished = table.Column<DateTime>(type: "datetime2", nullable: false),
                    referencecount = table.Column<long>(type: "bigint", nullable: false),
                    numberofcitations = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paper", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PaperAuthor",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaperId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaperAuthor", x => x.id);
                    table.ForeignKey(
                        name: "FK_PaperAuthor_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaperAuthor_Paper_PaperId",
                        column: x => x.PaperId,
                        principalTable: "Paper",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "id", "firstname", "lastname" },
                values: new object[] { new Guid("58ca7a2d-ef9d-47da-9ba2-2a27b76da85c"), "Abdullah", "Rexha" });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "id", "firstname", "lastname" },
                values: new object[] { new Guid("68ca7a2d-ef9d-47da-9ba2-2a27b76da85c"), "Shpetim", "Rexha" });

            migrationBuilder.CreateIndex(
                name: "IX_PaperAuthor_AuthorId",
                table: "PaperAuthor",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_PaperAuthor_PaperId",
                table: "PaperAuthor",
                column: "PaperId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaperAuthor");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Paper");
        }
    }
}
