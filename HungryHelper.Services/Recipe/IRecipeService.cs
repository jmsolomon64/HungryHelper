using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HungryHelper.Models.Recipe;

namespace HungryHelper.Services.Recipe
{
    public interface IRecipeService
    {
        Task<bool> RegisterRecipeAsync(RecipeRegister model);
    }
}