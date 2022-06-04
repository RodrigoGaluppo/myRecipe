using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recipe
{
    public partial class Favorites : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserInfo"] == null)
            {
                Response.Redirect("Login");


            }

        }




        public Models.Recipe[] SelectFavoriteRecipesByUserId()
        {
            string user_id = Convert.ToString(Session["userId"]);

            if (String.IsNullOrEmpty(user_id))
                Response.Redirect("Login");

            return DAL.Recipe.ListLikedByuserId(user_id);
        }
    }
}