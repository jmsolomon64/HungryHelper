using System;
using System.Threading.Tasks;
using HungryHelper.Models.FavoritedRecipes;
using HungryHelper.Data.Entities;
using HungryHelper.Data;
using System.Linq;

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

        public async Task<FavoritedRecipesRead> GetFavoritedRecipesByUserIdAsync(int Id)
        {
            var entity = _context.FavoritedRecipes.FirstOrDefault( i => i.UserId == Id);
            if (entity is null)
                {
                    return null;
                }
            
            var favoritedRecipesEntity = new FavoritedRecipesRead
            {
                Id = entity.Id,
                UserId = entity.UserId,
                RecipeId = entity.RecipeId
            };

            return favoritedRecipesEntity;
        }

        public List<FavoritedRecipesCreate> ViewAllFavoritedRecipes()
        {
            List<FavoritedRecipesCreate> listOfFavoritedRecipes = new List<FavoritedRecipesCreate>();
            var entity = _context.FavoritedRecipes;
            foreach (var favoritedRecipe in entity)
            {
                var favRecipe = new FavoritedRecipesCreate()
                {
                    Id = favoritedRecipe.Id,
                    UserId = favoritedRecipe.UserId,
                    RecipeId = favoritedRecipe.RecipeId
                };

                listOfFavoritedRecipes.Add(favRecipe);
            }
            return listOfFavoritedRecipes;
        }

        public async Task<bool> DeleteFavoritedRecipesByIdAsync(int Id)
        {
            var FavoritedRecipesEntity = _context.FavoritedRecipes.FirstOrDefault( i => i.Id == Id);
            

            _context.FavoritedRecipes.Remove(FavoritedRecipesEntity);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}