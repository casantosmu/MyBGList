using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyBGList.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "board_games",
                columns: table => new
                {
                    board_game_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    min_players = table.Column<int>(type: "integer", nullable: false),
                    max_players = table.Column<int>(type: "integer", nullable: false),
                    play_time = table.Column<int>(type: "integer", nullable: false),
                    min_age = table.Column<int>(type: "integer", nullable: false),
                    users_rated = table.Column<int>(type: "integer", nullable: false),
                    rating_average = table.Column<decimal>(type: "numeric(4,2)", precision: 4, scale: 2, nullable: false),
                    bgg_rank = table.Column<int>(type: "integer", nullable: false),
                    complexity_average = table.Column<decimal>(type: "numeric(4,2)", precision: 4, scale: 2, nullable: false),
                    owned_users = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_board_games", x => x.board_game_id);
                });

            migrationBuilder.CreateTable(
                name: "domains",
                columns: table => new
                {
                    domain_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_domains", x => x.domain_id);
                });

            migrationBuilder.CreateTable(
                name: "mechanics",
                columns: table => new
                {
                    mechanic_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    last_modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mechanics", x => x.mechanic_id);
                });

            migrationBuilder.CreateTable(
                name: "board_games_domains",
                columns: table => new
                {
                    board_game_id = table.Column<int>(type: "integer", nullable: false),
                    domain_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_board_games_domains", x => new { x.board_game_id, x.domain_id });
                    table.ForeignKey(
                        name: "FK_board_games_domains_board_games_board_game_id",
                        column: x => x.board_game_id,
                        principalTable: "board_games",
                        principalColumn: "board_game_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_board_games_domains_domains_domain_id",
                        column: x => x.domain_id,
                        principalTable: "domains",
                        principalColumn: "domain_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "board_games_mechanics",
                columns: table => new
                {
                    board_game_id = table.Column<int>(type: "integer", nullable: false),
                    mechanic_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_board_games_mechanics", x => new { x.board_game_id, x.mechanic_id });
                    table.ForeignKey(
                        name: "FK_board_games_mechanics_board_games_board_game_id",
                        column: x => x.board_game_id,
                        principalTable: "board_games",
                        principalColumn: "board_game_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_board_games_mechanics_mechanics_mechanic_id",
                        column: x => x.mechanic_id,
                        principalTable: "mechanics",
                        principalColumn: "mechanic_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_board_games_domains_domain_id",
                table: "board_games_domains",
                column: "domain_id");

            migrationBuilder.CreateIndex(
                name: "IX_board_games_mechanics_mechanic_id",
                table: "board_games_mechanics",
                column: "mechanic_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "board_games_domains");

            migrationBuilder.DropTable(
                name: "board_games_mechanics");

            migrationBuilder.DropTable(
                name: "domains");

            migrationBuilder.DropTable(
                name: "board_games");

            migrationBuilder.DropTable(
                name: "mechanics");
        }
    }
}
