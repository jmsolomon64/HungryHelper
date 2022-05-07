using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HungryHelper.Data;
using HungryHelper.Data.Entities;
using HungryHelper.Models.Ingredient;
using Microsoft.EntityFrameworkCore;

namespace HungryHelper.Services.Ingredient
{
    public class IngredientService : IIngredientService
    {
        private readonly ApplicationDbContext _context;
        public IngredientService(ApplicationDbContext context) //Constructor for service class, injects instance of DB into class
        {
            _context = context;
        }

        public async Task<bool> RegisterIngredientAsync(IngredientRegister model) //Explination for method called in Iservice
        {
            //uses method hoisted from bellow to check whether an ingredient is currently in the system 
            if (await GetIngredientByNameAsync(model.Name) != null)
            {
                return false; //if the method returns a value that is not null it will return false as ingredient already in there
            }

            var entity = new IngredientEntity // variable to hold the instance of an IngredientEntity
            {
                Name = model.Name, // sets the name of the Entity equal to the name of the model passed in
            };
            _context.Ingredients.Add(entity); // adds entity to the Ingredients DB dataset
            var numberOfChanges = await _context.SaveChangesAsync(); // sets variable equal to the number of rows changed (should be 1 if successful)

            return numberOfChanges == 1; //will return True if the  request handles properly
        }

        //method takes in a name and searches the DB context for an item with that name
        private async Task<IngredientEntity> GetIngredientByNameAsync(string name)
        {
            //if there is an Entity with that name it will be returned if not, the value returned will be null
            return await _context.Ingredients.FirstOrDefaultAsync(ingredient => ingredient.Name.ToLower() == name.ToLower());
        }

        public void AddRecipeToIngredient (int recipeId, int ingredientId)
        {
            var foundRecipe = _context.Recipes.Single(r => r.RecipeId == recipeId);
            var foundIngredient = _context.Ingredients.Single(i => i.IngredientId == ingredientId);
            foundIngredient.ListOfRecipes.Add(foundRecipe);
        }

        public async Task<bool> AddIngredientFromRecipeAsync(string name)
        {
            var ingredient = new IngredientRegister()
            {
                Name = name
            };
            return await RegisterIngredientAsync(ingredient);
        }
    }
}