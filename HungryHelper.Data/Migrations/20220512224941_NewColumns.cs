using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HungryHelper.Data.Migrations
{
    public partial class NewColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipeEntityRecipeId",
                table: "FavoritedRecipes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FavoritedRecipes_RecipeEntityRecipeId",
                table: "FavoritedRecipes",
                column: "RecipeEntityRecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoritedRecipes_Recipes_RecipeEntityRecipeId",
                table: "FavoritedRecipes",
                column: "RecipeEntityRecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoritedRecipes_Recipes_RecipeEntityRecipeId",
                table: "FavoritedRecipes");

            migrationBuilder.DropIndex(
                name: "IX_FavoritedRecipes_RecipeEntityRecipeId",
                table: "FavoritedRecipes");

            migrationBuilder.DropColumn(
                name: "RecipeEntityRecipeId",
                table: "FavoritedRecipes");
        }
    }
}
