using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryHelper.Models.ShoppingList
{
    public class ShoppingListItem
    {
        public int Id { get; set; }
        public string IngredientName { get; set; }
        public string Amount { get; set; }
        public DateTimeOffset UtcCreated { get; set; }
    }
}