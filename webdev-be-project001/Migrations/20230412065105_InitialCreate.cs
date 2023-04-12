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
                    IdColumn = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameColumn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTable", x => x.IdColumn);
                });

            migrationBuilder.CreateTable(
                name: "CountryTable",
                columns: table => new
                {
                    IdColumn = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameColumn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTable", x => x.IdColumn);
                });

            migrationBuilder.CreateTable(
                name: "PokemonTable",
                columns: table => new
                {
                    IdColumn = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameColumn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOBColumn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonTable", x => x.IdColumn);
                });

            migrationBuilder.CreateTable(
                name: "ReviewerTable",
                columns: table => new
                {
                    IdColumn = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstNameColumn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastNameColumn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewerTable", x => x.IdColumn);
                });

            migrationBuilder.CreateTable(
                name: "OwnerTable",
                columns: table => new
                {
                    IdColumn = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameColumn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GymColumn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryColumnIdColumn = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerTable", x => x.IdColumn);
                    table.ForeignKey(
                        name: "FK_OwnerTable_CountryTable_CountryColumnIdColumn",
                        column: x => x.CountryColumnIdColumn,
                        principalTable: "CountryTable",
                        principalColumn: "IdColumn",
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
                        principalColumn: "IdColumn",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonCategoryTable_PokemonTable_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "PokemonTable",
                        principalColumn: "IdColumn",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewTable",
                columns: table => new
                {
                    IdColumn = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleColumn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TextColumn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RatingColumn = table.Column<int>(type: "int", nullable: false),
                    ReviewerColumnIdColumn = table.Column<int>(type: "int", nullable: false),
                    PokemonColumnIdColumn = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewTable", x => x.IdColumn);
                    table.ForeignKey(
                        name: "FK_ReviewTable_PokemonTable_PokemonColumnIdColumn",
                        column: x => x.PokemonColumnIdColumn,
                        principalTable: "PokemonTable",
                        principalColumn: "IdColumn",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewTable_ReviewerTable_ReviewerColumnIdColumn",
                        column: x => x.ReviewerColumnIdColumn,
                        principalTable: "ReviewerTable",
                        principalColumn: "IdColumn",
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
                        principalColumn: "IdColumn",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonOwnerTable_PokemonTable_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "PokemonTable",
                        principalColumn: "IdColumn",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OwnerTable_CountryColumnIdColumn",
                table: "OwnerTable",
                column: "CountryColumnIdColumn");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonCategoryTable_CategoryId",
                table: "PokemonCategoryTable",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonOwnerTable_OwnerId",
                table: "PokemonOwnerTable",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewTable_PokemonColumnIdColumn",
                table: "ReviewTable",
                column: "PokemonColumnIdColumn");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewTable_ReviewerColumnIdColumn",
                table: "ReviewTable",
                column: "ReviewerColumnIdColumn");
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
