using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webdev_be_project001.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountryTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PokemonTable",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonTable", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ReviewerTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewerTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OwnerTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gym = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnerTable_CountryTable_CountryId",
                        column: x => x.CountryId,
                        principalTable: "CountryTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonCategoryTable",
                columns: table => new
                {
                    PokemonId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonCategoryTable", x => new { x.PokemonId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_PokemonCategoryTable_CategoryTable_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonCategoryTable_PokemonTable_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "PokemonTable",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ReviewerId = table.Column<int>(type: "int", nullable: false),
                    PokemonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewTable_PokemonTable_PokemonID",
                        column: x => x.PokemonID,
                        principalTable: "PokemonTable",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewTable_ReviewerTable_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "ReviewerTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonOwnerTable",
                columns: table => new
                {
                    PokemonId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonOwnerTable", x => new { x.PokemonId, x.OwnerId });
                    table.ForeignKey(
                        name: "FK_PokemonOwnerTable_OwnerTable_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "OwnerTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonOwnerTable_PokemonTable_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "PokemonTable",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OwnerTable_CountryId",
                table: "OwnerTable",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonCategoryTable_CategoryId",
                table: "PokemonCategoryTable",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonOwnerTable_OwnerId",
                table: "PokemonOwnerTable",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewTable_PokemonID",
                table: "ReviewTable",
                column: "PokemonID");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewTable_ReviewerId",
                table: "ReviewTable",
                column: "ReviewerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokemonCategoryTable");

            migrationBuilder.DropTable(
                name: "PokemonOwnerTable");

            migrationBuilder.DropTable(
                name: "ReviewTable");

            migrationBuilder.DropTable(
                name: "CategoryTable");

            migrationBuilder.DropTable(
                name: "OwnerTable");

            migrationBuilder.DropTable(
                name: "PokemonTable");

            migrationBuilder.DropTable(
                name: "ReviewerTable");

            migrationBuilder.DropTable(
                name: "CountryTable");
        }
    }
}
