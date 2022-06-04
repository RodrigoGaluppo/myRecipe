using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recipe
{
    public partial class ViewRecipe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Models.Recipe SelectRecipeById()
        {
            var url = new Uri(HttpContext.Current.Request.Url.AbsoluteUri);

            var recipe_id = Convert.ToInt32(HttpUtility.ParseQueryString(url.Query).Get("recipe_id"));

            Models.Recipe Recipe = DAL.Recipe.SelectRecipeByIdDashBoard(recipe_id);

            Recipe.recipe_id = recipe_id;
            return Recipe;
        }

        public Models.Category[] ListCategories()
        {
            return DAL.Category.ListAll();
        }

        public Models.IngredientList[] loadIngredientsList()
        {
            var url = new Uri(HttpContext.Current.Request.Url.AbsoluteUri);
            int recipeId = Convert.ToInt32(HttpUtility.ParseQueryString(url.Query).Get("recipe_id"));

            Models.IngredientList[] ingredients = DAL.Recipe.ListIngredientsByRecipeId(recipeId);
            return ingredients;
        }


        public Models.Difficulty[] ListDifficulty()
        {
            return DAL.Difficulty.ListAll();
        }

        public string GetEmailByUserId(string user_id)
        {
            Models.User user = DAL.User.SelectUserById(user_id);

            return user.email;
        }

        public bool UpdateRecipe(bool active)
        {
            var url = new Uri(HttpContext.Current.Request.Url.AbsoluteUri);

            var recipe_id = Convert.ToInt32(HttpUtility.ParseQueryString(url.Query).Get("recipe_id"));

            return DAL.Recipe.UpdateRecipe(recipe_id, active);
        }
    }
}