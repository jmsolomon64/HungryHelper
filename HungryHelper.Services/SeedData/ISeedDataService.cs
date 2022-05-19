namespace HungryHelper.Services.SeedData
{
    public interface ISeedDataService
    {
        Task<bool> SeedRecipesAsync();
        Task<bool> SeedUserProfilesAsync();
        Task<bool> SeedShoppingListAsync();
        Task<bool> SeedFavoritedRecipesAsync();
    }
}