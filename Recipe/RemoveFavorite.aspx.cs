using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recipe
{
    public partial class RemoveFavorite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserInfo"] == null)
            {
                Response.Redirect("Login");
                
            }
            else
            {
                string user_id = Convert.ToString(Session["userId"]);
                var url = new Uri(HttpContext.Current.Request.Url.AbsoluteUri);

                if (HttpUtility.ParseQueryString(url.Query).Get("id") == null)
                {
                    Response.Redirect("Default");
                }

                int recipe_id = Convert.ToInt32(HttpUtility.ParseQueryString(url.Query).Get("id"));

                if (String.IsNullOrEmpty(user_id))
                    Response.Redirect("Login");

                if (DAL.User.RemoveLikeFromRecipe(user_id, recipe_id))
                {
                    Response.Redirect("Favorites");
                }
                else
                {
                    Response.Redirect("DashBoard");
                }
            }

        }


    }
}