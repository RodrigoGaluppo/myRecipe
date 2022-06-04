using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recipe
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserInfo"] == null)
            {
                Response.Redirect("Login");

                
            }
            
        }

        public Models.User SelectUserInfo()
        {
            string user_id = Convert.ToString(Session["userId"]);

            if (String.IsNullOrEmpty(user_id))
                Response.Redirect("Login");

            Models.User user = DAL.User.SelectUserById(user_id);

            user.id = user_id;

            return user;
        }

        public bool UpdateUserInfo(string name,string email)
        {
            string user_id = Convert.ToString(Session["userId"]);

            if (String.IsNullOrEmpty(user_id))
                Response.Redirect("Login");

            return DAL.User.UpdateUserInfo(user_id, name, email);
        }

        public Models.Recipe[] SelectRecipeByUserId()
        {
            string user_id = Convert.ToString(Session["userId"]);

            if (String.IsNullOrEmpty(user_id))
                Response.Redirect("Login");

            return DAL.Recipe.ListByUserId(user_id);
        }
    }
}