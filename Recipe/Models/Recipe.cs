using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recipe.Models
{
    public class Recipe
    {
        public bool active { get; set; }
        public int recipe_id { get; set; }
        public string name { get; set; }
        public string preparation_method { get; set; }
        public string difficulty { get; set; }
        public string category { get; set; }
        public  string description { get; set; }
        public int number_of_people { get; set; }
        public int preparation_time { get; set; }
        public string img_url { get; set; }

        public int category_id { get; set; }

        public int difficulty_id { get; set; }

        public string user_id { get; set; }
        public string ingredientsList { get; set; }
        public float averageRate { get; set; }

        public Recipe() { }

    }
}