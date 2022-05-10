using System;
using System.Threading.Tasks;
using HungryHelper.Models.FavoritedRecipes;
using HungryHelper.Data.Entities;
using HungryHelper.Data;

namespace HungryHelper.Services.FavoritedRecipes
{
    public class FavoritedRecipesService : IFavoritedRecipesService
    {
        private readonly ApplicationDbContext _context;
        public FavoritedRecipesService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateFavoritedRecipesAsync(FavoritedRecipesCreate model)
        {
            var entity = new FavoritedRecipesEntity
            {
                UserProfileId = model.UserProfileId,
                RecipeId = model.RecipeId
            };

            _context.FavoritedRecipes.Add(entity);
            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<FavoritedRecipesRead> GetFavoritedRecipesByIdAsync(int Id)
        {
            var entity = await _context.FavoritedRecipes.FindAsync(Id);
            if (entity is null)
                {
                    return null;
                }
            
            var favoritedRecipesEntity = new FavoritedRecipesRead
            {
                Id = entity.Id,
                UserProfileId = entity.UserProfileId,
                RecipeId = entity.RecipeId
            };

            return favoritedRecipesEntity;
        }

        public async Task<bool> DeleteFavoritedRecipesAsync(int Id)
        {
            var FavoritedRecipesEntity = await _context.FavoritedRecipes.FindAsync(Id);
            

            _context.FavoritedRecipes.Remove(FavoritedRecipesEntity);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}