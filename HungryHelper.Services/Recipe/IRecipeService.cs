using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HungryHelper.Data.Entities;
using HungryHelper.Models.Recipe;

namespace HungryHelper.Services.Recipe
{
    public interface IRecipeService //*** Gotta ask the difference between this and the lass with the I ****
    {
        Task<bool> RegisterRecipeAsync(RecipeRegister model); //method for adding recipe
        int FindRecipeByName(string name);

        RecipeEntity ViewRecipeByName(int recipeId);
        List<RecipeEntity> GetAllRecipes();
    }
}