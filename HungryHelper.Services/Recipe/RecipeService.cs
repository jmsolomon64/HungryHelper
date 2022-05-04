using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HungryHelper.Data;
using HungryHelper.Data.Entities;
using HungryHelper.Models.Recipe;

namespace HungryHelper.Services.Recipe
{
    public class RecipeService : IRecipeService //inherits from the interface
    {
        private readonly ApplicationDbContext _context;
        public RecipeService(ApplicationDbContext context)
        {
            _context = context;
        }

        //Method takes in data from Recipe register model and uses it to help create a recipe entity
        public async Task<bool> RegisterRecipeAsync(RecipeRegister model)
        {
            var entity = new RecipeEntity
            {
                Category = model.Category,
                Name = model.Name,
                Ingredients = model.Ingredients,
                Measurements = model.Measurements,
                Directions = model.Directions,
                CreatedDate = DateTime.Now
            };

            _context.Recipes.Add(entity); //Entity 
            var numberOfChanges = await _context.SaveChangesAsync(); //saves number of rows changed

            return numberOfChanges == 1; //will return bool determined by numberOfChanges being 1 or not
        }
    }
}