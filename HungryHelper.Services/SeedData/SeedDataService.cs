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

        // private void SeedUserProfiles()
        // {
        //     // returns the count of rows in the UserProfile table
        //     int items = _context.UserProfile.Count();
        //     // if there are records, exit method
        //     if (items == 0)
        //     {
                
        //     }
        //     // if no records (or less than 2 or something), add seed data
        // }

        public async Task<bool> SeedRecipesAsync()
        {
            int items = _context.Recipes.Count();
            if (items == 0)
            {
                List<string> listOfIngredients = new List<string>;
                listOfIngredients.Add("Tuna");
                listOfIngredients.Add("Noodle");
                listOfIngredients.Add("Casserole");
                string directions = "Throw it all in the pot and cook it up!";

                // call register method, hard code like three recipes
                var firstRecipe = new RecipeRegister("Dinner");
                
                return await _recipe.RegisterRecipeAsync(firstRecipe);

                // var secondRecipe = new RecipeRegister()
                // {
                //     Category = "Lunch",
                //     Name = "Onions",
                //     ListOfIngredients = {
                //         "Onions",
                //         "Garlic powder",
                //         "Black Pepper",
                //         "salt"
                //     },
                //     Directions = "Slice the onions and add the seasoning, for the love of god"
                // };

                // return await _recipe.RegisterRecipeAsync(secondRecipe);
            }
            else 
            {
                return false;
            }
        }
        private void SeedShoppingList() {}
        private void SeedFavoritedRecipes() {}
    }
}