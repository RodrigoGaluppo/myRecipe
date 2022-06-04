using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Services;

namespace Recipe
{
    public partial class CreateRecipe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string user_id = Convert.ToString(Session["userId"]);

            if (String.IsNullOrEmpty(user_id))
            {
                Response.Redirect("Login");
            }

        }
        public string getuserId()
        {

            string user_id = Convert.ToString(Session["userId"]);

            return user_id;

        }

        /* Servico Web para criar receita */

        [WebMethod]

        public static string Test(string name, string description, List<Models.IngredientList> ingredients, string preparation_method,
            int number_of_people,
            int preparation_time, int difficulty_id, int category_id, string filename, string user_id)
        {

            Models.IngredientList[] newIngredientsList = new Models.IngredientList[ingredients.Count];

            int i = 0;

            foreach (Models.IngredientList ingredient in ingredients)
            {
                
                newIngredientsList[i] = ingredient;
                i++;
            }

            try
            {
                DAL.Recipe.CreateRecipe(name, user_id, description, (int)preparation_time, (int)category_id, (int)difficulty_id, filename, number_of_people, preparation_method, newIngredientsList,false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            return "ok";
        }
    }
}