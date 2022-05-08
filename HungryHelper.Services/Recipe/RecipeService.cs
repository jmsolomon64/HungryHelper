using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HungryHelper.Data;
using HungryHelper.Data.Entities;
using HungryHelper.Models.Recipe;
using HungryHelper.Services.Ingredient;

namespace HungryHelper.Services.Recipe
{
    public class RecipeService : IRecipeService //inherits from the interface
    {
        private readonly ApplicationDbContext _context;
        private readonly IIngredientService _ingredientS;
        public RecipeService(ApplicationDbContext context, IIngredientService service)
        {
            _context = context;
            _ingredientS = service;
        }

        //Method takes in data from Recipe register model and uses it to help create a recipe entity
        public async Task<bool> RegisterRecipeAsync(RecipeRegister model) //API Uses this method
        {
            var entity = new RecipeEntity //makes new RecipeEntity pulling from the model injected into this method
            {
                Category = model.Category,
                Name = model.Name,
                Directions = model.Directions,
                CreatedDate = DateTime.Now //DateTime not in entity  will be figured out in this method
            };

            var recipeFound = FindRecipeByName(model.Name); //looks to see if recipe name already exists

            if (recipeFound >= 0)
            {
                return false;
            }

            _context.Recipes.Add(entity); //Entity added to dbset
            var numberOfChanges = await _context.SaveChangesAsync(); //holds number of rows changed, will be given 1 if successful and 0 if not

            int recipeId = FindRecipeByName(entity.Name);

            for (int i = 0; i < model.ListOfIngredients.Count; i++) //itterates through all of the ingredients in the list
            {
                int ingredientId = FindIngredientByName(model.ListOfIngredients[i]); //uses i to get current index and uses string in index to find 
                AddIngredientToRecipe(ingredientId, recipeId);
            }

            return numberOfChanges == 1; //will return bool determined by numberOfChanges being 1 or not
        }
        //adds Ingredient to recipe by both of their Ids
        private void AddIngredientToRecipe(int ingredientId, int recipeId)
        {
            var foundIngredient = _context.Ingredients.Single(i => i.IngredientId == ingredientId); //finds Ingredient by id
            var foundRecipe = _context.Recipes.Single(r => r.RecipeId == recipeId); //finds recipe by id
            foundRecipe.ListOfIngredients.Add(foundIngredient); //appends new ingredient into recipe's list of ingredient
        }
        //Finds ingredients in DB from recipe by ingredient name
        public int FindIngredientByName(string name)
        {
            var foundIngredient = _context.Ingredients.SingleOrDefault(i => i.Name.ToUpper() == name.ToUpper()); //finds ingredient by name

            if (foundIngredient == null)
            {
                _ingredientS.AddIngredientFromRecipeAsync(name).Wait(); //will create Ingredient if name isn't in ingredients table
                foundIngredient = _context.Ingredients.SingleOrDefault(i => i.Name.ToUpper() == name.ToUpper());
            }

            return foundIngredient.IngredientId; //returns Id of ingredient
        }
        //Finds recipe by the name and then returns the ID
        public int FindRecipeByName(string name)
        {
            var foundRecipe = _context.Recipes.SingleOrDefault(r => r.Name.ToUpper() == name.ToUpper());
            if (foundRecipe == null)
            {
                return -1;
            }
            return foundRecipe.RecipeId;
        }
        //Finds The Recipe from the ID and returns The recipe Entity
        public RecipeEntity ViewRecipeByName(int recipeId)
        {
            var recipe = _context.Recipes.SingleOrDefault(i => i.RecipeId == recipeId);

            if (recipe == null)
            {
                return null;
            }
            return recipe;
        }

        public List<RecipeEntity> GetAllRecipes()
        {
            List<RecipeEntity> listofRecipes = new List<RecipeEntity>();
            var recipes = _context.Recipes;
            foreach (var recipe in recipes)
            {
                listofRecipes.Add(recipe);
            }

            return listofRecipes;
        }
    }
}