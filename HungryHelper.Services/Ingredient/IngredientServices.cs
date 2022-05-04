using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HungryHelper.Data;
using HungryHelper.Data.Entities;
using HungryHelper.Models.Ingredient;

namespace HungryHelper.Services.Ingredient
{
    public class IngredientService : IIngredientServices
    {
        private readonly ApplicationDbContext _context;
        public IngredientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterIngredientAsync(IngredientRegister model)
        {
            var entity = new IngredientEntity
            {
                Name = model.Name
            };
            _context.Ingredients.Add(entity);
            
        }
    }
}