using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HungryHelper.Models.Ingredient;

namespace HungryHelper.Services.Ingredient
{
    public interface IIngredientServices
    {
        Task<bool> RegisterIngredientAsync(IngredientRegister model); //Contrtact saying this method can be used ***Genuinely not sure on this one***
    }
}