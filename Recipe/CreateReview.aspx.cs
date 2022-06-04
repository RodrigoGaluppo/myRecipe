using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recipe
{
    public partial class CreateReview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var url = new Uri(HttpContext.Current.Request.Url.AbsoluteUri);

            if (HttpUtility.ParseQueryString(url.Query).Get("id") == null)
            {
                Response.Redirect("Default");
            }

            string user_id = Convert.ToString(Session["userId"]);

            if (String.IsNullOrEmpty(user_id))
            {
                Response.Redirect("Login");
            }
        }

        public void MakeReview(string comment, double rate)
        {
            var url = new Uri(HttpContext.Current.Request.Url.AbsoluteUri);

            if(HttpUtility.ParseQueryString(url.Query).Get("id") == null)
            {
                Response.Redirect("Default");
            }
            int recipeId = Convert.ToInt32(HttpUtility.ParseQueryString(url.Query).Get("id"));

            if(recipeId == 0)
            {
                Response.Redirect("Default");
            }

            string user_id = Convert.ToString(Session["userId"]);

            if (String.IsNullOrEmpty(user_id))
            {
                Response.Redirect("Login");
            }

            if (DAL.User.CreateReview(comment, (float)rate, recipeId, user_id))
                Response.Redirect($"Recipe?id={recipeId}");
            else
            {
                Response.Write(Models.Message.DisplayMessage("danger","Não foi possivel fazer avaliação"));
            }
        }
    }
}