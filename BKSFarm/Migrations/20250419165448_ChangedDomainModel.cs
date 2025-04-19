using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BKSFarm.api.Migrations
{
    /// <inheritdoc />
    public partial class ChangedDomainModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Users_UserId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Eggs_Users_UserId",
                table: "Eggs");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Users_UserId",
                table: "Plants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plants",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_Plants_UserId",
                table: "Plants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Eggs",
                table: "Eggs");

            migrationBuilder.DropIndex(
                name: "IX_Eggs_UserId",
                table: "Eggs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Animals",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_UserId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "PlantId",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "DateCreate",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "PlanType",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "PlantImageUrl",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "PlantStage",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "EggId",
                table: "Eggs");

            migrationBuilder.DropColumn(
                name: "AnimalId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "AnimalImageUrl",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "AnimalStage",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "DateCreate",
                table: "Animals");

            migrationBuilder.RenameColumn(
                name: "UserSeedId",
                table: "UserSeeds",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SeedName",
                table: "Seeds",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "SeedImageUrl",
                table: "Seeds",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "SeedId",
                table: "Seeds",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Plants",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PlantName",
                table: "Plants",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Eggs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EggName",
                table: "Eggs",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "EggImageUrl",
                table: "Eggs",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Animals",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AnimalType",
                table: "Animals",
                newName: "Type");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UserSeeds",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "UserSeeds",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plants",
                table: "Plants",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Eggs",
                table: "Eggs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Animals",
                table: "Animals",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserAnimals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    Stage = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    AnimalId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnimals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAnimals_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAnimals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserEggs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    EggId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEggs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEggs_Eggs_EggId",
                        column: x => x.EggId,
                        principalTable: "Eggs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserEggs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPlants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    Stage = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlantId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPlants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPlants_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPlants_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAnimals_AnimalId",
                table: "UserAnimals",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnimals_UserId",
                table: "UserAnimals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEggs_EggId",
                table: "UserEggs",
                column: "EggId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEggs_UserId",
                table: "UserEggs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPlants_PlantId",
                table: "UserPlants",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPlants_UserId",
                table: "UserPlants",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAnimals");

            migrationBuilder.DropTable(
                name: "UserEggs");

            migrationBuilder.DropTable(
                name: "UserPlants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plants",
                table: "Plants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Eggs",
                table: "Eggs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Animals",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "UserSeeds");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "UserSeeds");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserSeeds",
                newName: "UserSeedId");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Seeds",
                newName: "SeedName");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Seeds",
                newName: "SeedImageUrl");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Seeds",
                newName: "SeedId");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Plants",
                newName: "PlantName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Plants",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Eggs",
                newName: "EggName");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Eggs",
                newName: "EggImageUrl");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Eggs",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Animals",
                newName: "AnimalType");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Animals",
                newName: "UserId");

            migrationBuilder.AddColumn<Guid>(
                name: "PlantId",
                table: "Plants",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<long>(
                name: "DateCreate",
                table: "Plants",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "PlanType",
                table: "Plants",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlantImageUrl",
                table: "Plants",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PlantStage",
                table: "Plants",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "EggId",
                table: "Eggs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AnimalId",
                table: "Animals",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "AnimalImageUrl",
                table: "Animals",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AnimalStage",
                table: "Animals",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "DateCreate",
                table: "Animals",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plants",
                table: "Plants",
                column: "PlantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Eggs",
                table: "Eggs",
                column: "EggId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Animals",
                table: "Animals",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_UserId",
                table: "Plants",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Eggs_UserId",
                table: "Eggs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_UserId",
                table: "Animals",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Users_UserId",
                table: "Animals",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Eggs_Users_UserId",
                table: "Eggs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Users_UserId",
                table: "Plants",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
