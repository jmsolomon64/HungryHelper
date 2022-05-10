using HungryHelper.Models.FavoritedRecipes;

namespace HungryHelper.Services.FavoritedRecipes
{
    public interface IFavoritedRecipesService
    {
        Task<bool> CreateFavoritedRecipesAsync(FavoritedRecipesCreate model);
        Task<FavoritedRecipesRead> GetFavoritedRecipesByIdAsync(int userProfileId);
        Task<bool> DeleteFavoritedRecipesAsync(int userProfileId);
    }
}