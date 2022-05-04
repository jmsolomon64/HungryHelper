using HungryHelper.Models.FavoritedRecipes;
using HungryHelper.Data.Entities;

namespace HungryHelper.Services.FavoritedRecipes
{
    public class FavoritedRecipesService : IFavoritedRecipesService
    {
        public async Task<bool> CreateFavoritedRecipesAsync(FavoritedRecipesCreate model);

        var entity = new FavoritedRecipesEntity
        {
            Id = Models.Id,
            UserId = model.
            RecipeId
        }
    }
}