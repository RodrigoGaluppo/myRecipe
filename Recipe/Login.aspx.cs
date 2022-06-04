using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Recipe.Models;

namespace Recipe
{
    public partial class Login : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool Log(string email,string password)
        {

            string userId = DAL.User.Login(email, password);

            if(!String.IsNullOrEmpty(userId))
            {
                Session.Clear();
                Session["UserInfo"] = true;
                Session["UserId"] = userId;

                return true;
            }
            return false ;
        }

        

    }
}