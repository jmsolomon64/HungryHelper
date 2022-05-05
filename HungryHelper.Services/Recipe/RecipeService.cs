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
        public async Task<bool> RegisterRecipeAsync(RecipeRegister model) //API Uses this method
        {
            var entity = new RecipeEntity //makes new RecipeEntity pulling from the model injected into this method
            {
                Category = model.Category,
                Name = model.Name,
                Ingredients = model.Ingredients,
                Measurements = model.Measurements,
                Directions = model.Directions,
                CreatedDate = DateTime.Now //DateTime not in entity  will be figured out in this method
            };

            _context.Recipes.Add(entity); //Entity added to dbset
            var numberOfChanges = await _context.SaveChangesAsync(); //holds number of rows changed, will be given 1 if successful and 0 if not

            return numberOfChanges == 1; //will return bool determined by numberOfChanges being 1 or not
        }
    }
}