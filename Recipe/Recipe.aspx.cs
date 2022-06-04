using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Recipe.DAL;
using Recipe.Models;

namespace Recipe
{
    public partial class Recipe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var url = new Uri(HttpContext.Current.Request.Url.AbsoluteUri);

            if (HttpUtility.ParseQueryString(url.Query).Get("id") == null)
            {
                Response.Redirect("Default");
            }
      

        }

        public static Models.Recipe loadRecipe()
        {
            var url = new Uri(HttpContext.Current.Request.Url.AbsoluteUri);
            int recipeId = Convert.ToInt32(HttpUtility.ParseQueryString(url.Query).Get("id"));

            Models.Recipe recipe = DAL.Recipe.SelectRecipeById(recipeId);
            recipe.recipe_id = recipeId;
            return recipe;

        }

        public void AddLike(object sender, EventArgs e)
        {
            var url = new Uri(HttpContext.Current.Request.Url.AbsoluteUri);
            int recipeId = Convert.ToInt32(HttpUtility.ParseQueryString(url.Query).Get("id"));
            string user_id = Convert.ToString(Session["userId"]);

            if (String.IsNullOrEmpty(user_id))
            {
                Response.Redirect("Login");
            }

            if (DAL.User.AddLikeToRecipe(user_id, recipeId))
            {
                Response.Redirect("Favorites");
            }
            
        }

        public  Models.IngredientList[] loadIngredientsList()
        {
            var url = new Uri(HttpContext.Current.Request.Url.AbsoluteUri);
            int recipeId = Convert.ToInt32(HttpUtility.ParseQueryString(url.Query).Get("id"));

            if (recipeId == null)
                Response.Redirect("Default");

            Models.IngredientList[] ingredients =  DAL.Recipe.ListIngredientsByRecipeId(recipeId);
            return ingredients;
        }

        public  Models.Rate[] loadRates()
        {
            var url = new Uri(HttpContext.Current.Request.Url.AbsoluteUri);
            int recipeId = Convert.ToInt32(HttpUtility.ParseQueryString(url.Query).Get("id"));

            Models.Rate[] rates = DAL.Recipe.ListRates(recipeId);

            return rates;

        }

        public static float calculateAverage()
        {
            var url = new Uri(HttpContext.Current.Request.Url.AbsoluteUri);
            int recipeId = Convert.ToInt32(HttpUtility.ParseQueryString(url.Query).Get("id"));

            float average = DAL.Recipe.CalculateRateAverage(recipeId);

            return average;
        }
    }
}