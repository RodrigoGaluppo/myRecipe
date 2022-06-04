using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recipe
{
    public partial class DashBoardLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public bool Login(string email, string password)
        {

            string userId = DAL.User.LoginAdmin(email, password);

            if (!String.IsNullOrEmpty(userId))
            {
                Session.Clear();
                Session["UserDashBoard"] = true;
                Session["UserId"] = userId;

                return true;
            }
            return false;
        }
    }
}