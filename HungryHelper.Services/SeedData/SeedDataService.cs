using HungryHelper.Data;
using HungryHelper.Models.Recipe;
using HungryHelper.Models.UserProfile;
using HungryHelper.Services.Recipe;
using HungryHelper.Services.UserProfile;

namespace HungryHelper.Services.SeedData
{
    public class SeedDataService : ISeedDataService
    {
        private readonly ApplicationDbContext _context;
        private readonly IRecipeService _recipe;
        private readonly IUserProfileService _userProfile;


        public SeedDataService(ApplicationDbContext context, IRecipeService recipe, IUserProfileService userProfile)
        {
            _context = context;
            _recipe = recipe;
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
    }
}