using HungryHelper.Models.FavoritedRecipes;

namespace HungryHelper.Services.FavoritedRecipes
{
    public interface IFavoritedRecipesService
    {
        Task<bool> CreateFavoritedRecipesAsync(FavoritedRecipesCreate model);

        Task<FavoritedRecipesRead> GetFavoritedRecipesByUserIdAsync(int userId);
        
        Task<bool> DeleteFavoritedRecipesByIdAsync(int id);
    }
}