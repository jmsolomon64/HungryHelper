using HungryHelper.Data;

namespace HungryHelper.Services.SeedData
{
    public class SeedDataService : ISeedDataService
    {
        private readonly ApplicationDbContext _context;
        public SeedDataService(ApplicationDbContext context)
        {
            _context = context;
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
        private void SeedIngredients() {}
        private void SeedRecipes()
        {
            
        }
        private void SeedShoppingList() {}
        private void SeedFavoritedRecipes() {}
    }
}