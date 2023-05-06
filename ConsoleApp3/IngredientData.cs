using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class IngredientData
    {
        public Ingredient Ingredient { get; set; }
        public int IngredientCount { get; set; }
        public IngredientData(Ingredient ingredient, int ingredientCount)
        {
            Ingredient = ingredient;
            IngredientCount = ingredientCount;
        }
    }
}
