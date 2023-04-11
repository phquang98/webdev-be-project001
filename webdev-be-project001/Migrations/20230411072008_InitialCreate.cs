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
                name: "CategoryClt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryClt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountryClt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryClt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PokemonClt",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonClt", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ReviewerClt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewerClt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OwnerClt",
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
                    table.PrimaryKey("PK_OwnerClt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnerClt_CountryClt_CountryId",
                        column: x => x.CountryId,
                        principalTable: "CountryClt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonCategoryClt",
                columns: table => new
                {
                    PokemonId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonCategoryClt", x => new { x.PokemonId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_PokemonCategoryClt_CategoryClt_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryClt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonCategoryClt_PokemonClt_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "PokemonClt",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewClt",
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
                    table.PrimaryKey("PK_ReviewClt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewClt_PokemonClt_PokemonID",
                        column: x => x.PokemonID,
                        principalTable: "PokemonClt",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewClt_ReviewerClt_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "ReviewerClt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonOwnerClt",
                columns: table => new
                {
                    PokemonId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonOwnerClt", x => new { x.PokemonId, x.OwnerId });
                    table.ForeignKey(
                        name: "FK_PokemonOwnerClt_OwnerClt_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "OwnerClt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonOwnerClt_PokemonClt_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "PokemonClt",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OwnerClt_CountryId",
                table: "OwnerClt",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonCategoryClt_CategoryId",
                table: "PokemonCategoryClt",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonOwnerClt_OwnerId",
                table: "PokemonOwnerClt",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewClt_PokemonID",
                table: "ReviewClt",
                column: "PokemonID");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewClt_ReviewerId",
                table: "ReviewClt",
                column: "ReviewerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokemonCategoryClt");

            migrationBuilder.DropTable(
                name: "PokemonOwnerClt");

            migrationBuilder.DropTable(
                name: "ReviewClt");

            migrationBuilder.DropTable(
                name: "CategoryClt");

            migrationBuilder.DropTable(
                name: "OwnerClt");

            migrationBuilder.DropTable(
                name: "PokemonClt");

            migrationBuilder.DropTable(
                name: "ReviewerClt");

            migrationBuilder.DropTable(
                name: "CountryClt");
        }
    }
}
