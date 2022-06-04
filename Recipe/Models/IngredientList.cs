using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recipe.Models
{
    public class IngredientList
    {
        public float quantity { get; set; }
        public int recipe_id { get; set; }
        public int measure_id { get; set; }
        public int ingredient_id { get; set; }

        public string ingredient { get; set; }

        public string measure { get; set; }
    }
}