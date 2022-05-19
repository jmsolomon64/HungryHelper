namespace HungryHelper.Services.SeedData
{
    public interface ISeedDataService
    {
        Task<bool> SeedRecipesAsync();
        Task<bool> SeedUserProfilesAsync();
    }
}