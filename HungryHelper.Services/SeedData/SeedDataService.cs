using HungryHelper.Data;
using HungryHelper.Models.Recipe;
using HungryHelper.Services.Recipe;

namespace HungryHelper.Services.SeedData
{
    public class SeedDataService : ISeedDataService
    {
        private readonly ApplicationDbContext _context;
        private readonly IRecipeService _recipe;
        public SeedDataService(ApplicationDbContext context, IRecipeService recipe)
        {
            _context = context;
            _recipe = recipe;
        }

        private void SeedUserProfiles()
        {
            // returns the count of rows in the UserProfile table
            int items = _context.UserProfile.Count();
            // if there are records, exit method
            if (items == 0)
            {
                
            }
            // if no records (or less than 2 or something), add seed data
        }

        private void SeedRecipes()
        {
            int items = _context.Recipes.Count();
            if (items == 0)
            {
                // call register method, hard code like three recipes
                RecipeRegister firstRecipe = new RecipeRegister
                {
                    Category = "Dinner",
                    Name = "Tuna Noodle Casserole",
                    ListOfIngredients = {
                        "Tuna",
                        "Noodle",
                        "Casserole"
                    },
                    Directions = "Throw it all in the pot and cook it up!"
                };
                RecipeRegister secondRecipe = new RecipeRegister
                {
                    Category = "Lunch",
                    Name = "Onions",
                    ListOfIngredients = {
                        "Onions",
                        "Garlic powder",
                        "Black Pepper",
                        "salt"
                    },
                    Directions = "Slice the onions and add the seasoning, for the love of god"
                };

                _recipe.RegisterRecipeAsync(firstRecipe);
                _recipe.RegisterRecipeAsync(secondRecipe);
            }
        }
        private void SeedShoppingList() {}
        private void SeedFavoritedRecipes() {}
    }
}