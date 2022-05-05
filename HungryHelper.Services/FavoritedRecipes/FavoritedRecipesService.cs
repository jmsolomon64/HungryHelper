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
                UserId = model.UserId,
                RecipeId = model.RecipeId
            };

            _context.FavoritedRecipes.Add(entity);
            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }
    }
}