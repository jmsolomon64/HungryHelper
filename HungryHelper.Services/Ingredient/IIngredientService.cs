using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HungryHelper.Data.Entities;
using HungryHelper.Models.Ingredient;

namespace HungryHelper.Services.Ingredient
{
    public interface IIngredientService
    {
        Task<bool> RegisterIngredientAsync(IngredientRegister model); //Contrtact saying this method can be used ***Genuinely not sure on this one***

        Task<bool> AddIngredientFromRecipeAsync(string name);
        int AddRecipeToIngredient(int recipeId, int ingredientId);

        List<IngredientEntity> GetAllIngredients();
    }
}