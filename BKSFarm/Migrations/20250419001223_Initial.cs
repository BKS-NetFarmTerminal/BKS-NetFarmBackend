using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BKSFarm.api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seeds",
                columns: table => new
                {
                    SeedId = table.Column<Guid>(type: "uuid", nullable: false),
                    SeedName = table.Column<string>(type: "text", nullable: false),
                    SeedImageUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seeds", x => x.SeedId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: false),
                    FieldCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    AnimalId = table.Column<Guid>(type: "uuid", nullable: false),
                    AnimalImageUrl = table.Column<string>(type: "text", nullable: false),
                    AnimalType = table.Column<string>(type: "text", nullable: false),
                    AnimalStage = table.Column<int>(type: "integer", nullable: false),
                    DateCreate = table.Column<long>(type: "bigint", nullable: false),
                    DieTime = table.Column<long>(type: "bigint", nullable: false),
                    TimeToLvlUp = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK_Animals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Eggs",
                columns: table => new
                {
                    EggId = table.Column<Guid>(type: "uuid", nullable: false),
                    EggName = table.Column<string>(type: "text", nullable: false),
                    EggImageUrl = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eggs", x => x.EggId);
                    table.ForeignKey(
                        name: "FK_Eggs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    PlantId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlantName = table.Column<string>(type: "text", nullable: false),
                    PlanType = table.Column<string>(type: "text", nullable: true),
                    PlantImageUrl = table.Column<string>(type: "text", nullable: false),
                    PlantStage = table.Column<int>(type: "integer", nullable: false),
                    DateCreate = table.Column<long>(type: "bigint", nullable: false),
                    DieTime = table.Column<long>(type: "bigint", nullable: false),
                    TimeToLvlUp = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.PlantId);
                    table.ForeignKey(
                        name: "FK_Plants_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSeeds",
                columns: table => new
                {
                    UserSeedId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    SeedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSeeds", x => x.UserSeedId);
                    table.ForeignKey(
                        name: "FK_UserSeeds_Seeds_SeedId",
                        column: x => x.SeedId,
                        principalTable: "Seeds",
                        principalColumn: "SeedId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSeeds_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_UserId",
                table: "Animals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Eggs_UserId",
                table: "Eggs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_UserId",
                table: "Plants",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSeeds_SeedId",
                table: "UserSeeds",
                column: "SeedId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSeeds_UserId",
                table: "UserSeeds",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Eggs");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "UserSeeds");

            migrationBuilder.DropTable(
                name: "Seeds");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
