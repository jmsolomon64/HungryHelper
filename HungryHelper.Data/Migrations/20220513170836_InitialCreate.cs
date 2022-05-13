using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HungryHelper.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Directions = table.Column<string>(type: "nvarchar(max)", maxLength: 100000, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.RecipeId);
                });

            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateJoined = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CookingExperienceLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FavoriteFood = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FavoritedRecipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    RecipeEntityRecipeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritedRecipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoritedRecipes_Recipes_RecipeEntityRecipeId",
                        column: x => x.RecipeEntityRecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId");
                });

            migrationBuilder.CreateTable(
                name: "IngredientEntityRecipeEntity",
                columns: table => new
                {
                    ListOfIngredientsIngredientId = table.Column<int>(type: "int", nullable: false),
                    ListOfRecipesRecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientEntityRecipeEntity", x => new { x.ListOfIngredientsIngredientId, x.ListOfRecipesRecipeId });
                    table.ForeignKey(
                        name: "FK_IngredientEntityRecipeEntity_Ingredients_ListOfIngredientsIngredientId",
                        column: x => x.ListOfIngredientsIngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientEntityRecipeEntity_Recipes_ListOfRecipesRecipeId",
                        column: x => x.ListOfRecipesRecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingList",
                columns: table => new
                {
                    ListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UtcAdded = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UtcModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingList", x => x.ListId);
                    table.ForeignKey(
                        name: "FK_ShoppingList_UserProfile_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoritedRecipes_RecipeEntityRecipeId",
                table: "FavoritedRecipes",
                column: "RecipeEntityRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientEntityRecipeEntity_ListOfRecipesRecipeId",
                table: "IngredientEntityRecipeEntity",
                column: "ListOfRecipesRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingList_OwnerId",
                table: "ShoppingList",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoritedRecipes");

            migrationBuilder.DropTable(
                name: "IngredientEntityRecipeEntity");

            migrationBuilder.DropTable(
                name: "ShoppingList");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "UserProfile");
        }
    }
}
