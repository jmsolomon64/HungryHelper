using HungryHelper.Data;
using HungryHelper.Models.FavoritedRecipes;
using HungryHelper.Models.Recipe;
using HungryHelper.Models.UserProfile;
using HungryHelper.Models.ShoppingList;
using HungryHelper.Services.FavoritedRecipes;
using HungryHelper.Services.Recipe;
using HungryHelper.Services.UserProfile;
using HungryHelper.Services.ShoppingList;

namespace HungryHelper.Services.SeedData
{
    public class SeedDataService : ISeedDataService
    {
        private readonly ApplicationDbContext _context;
        private readonly IRecipeService _recipe;
        private readonly IUserProfileService _userProfile;
        private readonly IShoppingListService _shoppingList;
        private readonly IFavoritedRecipesService _favoritedRecipe;

        public SeedDataService(ApplicationDbContext context, IRecipeService recipe, IShoppingListService shoppingList, IFavoritedRecipesService favoritedRecipe, IUserProfileService userProfile)
        {
            _context = context;
            _recipe = recipe;
            _shoppingList = shoppingList;
            _favoritedRecipe = favoritedRecipe;
            _userProfile = userProfile;
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
                var firstRecipe = new RecipeRegister()
                {
                    Category = "Lunch",
                    Name = "Onions",
                    ListOfIngredients = new List<string>()
                    {
                        "Onions",
                        "Garlic powder",
                        "Black Pepper",
                        "salt"
                    },
                    Directions = "Slice the onions and add the seasoning, for the love of god"
                };

                return await _recipe.RegisterRecipeAsync(firstRecipe);
            }
            else 
            {
                return false;
            }
        }

        public async Task<bool> SeedUserProfilesAsync()
        {
            int userCount = _context.UserProfile.Count();
            if (userCount == 0)
            {
                var firstUser = new UserProfileRegister()
                {
                    Username = "UserOne",
                    Password = "UserOnePassword",
                    ConfirmPassword = "UserOnePassword",
                    CookingExperienceLevel = "Low",
                    FirstName = "User",
                    LastName = "One",
                    FavoriteFood = "Escargot"
                };

                var secondUser = new UserProfileRegister()
                {
                    Username = "UserTwo",
                    Password = "UserTwoPassword",
                    ConfirmPassword = "UserTwoPassword",
                    CookingExperienceLevel = "High",
                    FirstName = "User",
                    LastName = "Two",
                    FavoriteFood = "Onions"
                };

                var thirdUser = new UserProfileRegister()
                {
                    Username = "UserThree",
                    Password = "UserThreePassword",
                    ConfirmPassword = "UserThreePassword",
                    CookingExperienceLevel = "Medium",
                    FirstName = "User",
                    LastName = "Three",
                    FavoriteFood = "Pizza with or without Pineapple"
                };

                await _userProfile.RegisterUserProfileAsync(firstUser);
                await _userProfile.RegisterUserProfileAsync(secondUser);
                await _userProfile.RegisterUserProfileAsync(thirdUser);
                return true;
            }

            return false;
        }

        public async Task<bool> SeedShoppingListAsync()
        {
            int items = _context.ShoppingList.Count();
            if (items == 0)
            {
                var firstShoppingList = new ShoppingListCreate()
                {
                    IngredientName = "Avocado",
                    Amount = "4",
                };

                return await _shoppingList.CreateShoppingListAsync(firstShoppingList);
            }
            else 
            {
                return false;
            }
        }
        
        public async Task<bool> SeedFavoritedRecipesAsync()
        {
            int items = _context.FavoritedRecipes.Count();
            if (items == 0)
            {
                var firstFavoritedRecipe = new FavoritedRecipesCreate()
                {
                    UserId = 1005,
                    RecipeId = 4,
                };

                return await _favoritedRecipe.CreateFavoritedRecipesAsync(firstFavoritedRecipe);
            }
            else 
            {
                return false;
            }
        }
    }
}