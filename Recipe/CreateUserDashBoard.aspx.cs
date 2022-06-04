using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recipe
{
    public partial class CreateUserDashBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool Create(string name, string email, string password,int type_id)
        {
            return DAL.User.CreateUser(name, email, password,type_id);
        }
    }
}