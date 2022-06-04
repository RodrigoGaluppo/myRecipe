using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recipe
{
    public partial class ViewUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Models.User loadUserInfo()
        {
            
            var url = new Uri(HttpContext.Current.Request.Url.AbsoluteUri);

            var user_id = HttpUtility.ParseQueryString(url.Query).Get("user_id");

            if (user_id == null)
                Response.Redirect("DashBoard");
            else
                user_id = user_id.ToString();

            Models.User user = DAL.User.SelectUserById(user_id);

            if (String.IsNullOrEmpty(user.name) || String.IsNullOrEmpty(user.email))
                Response.Redirect("DashBoard");

            user.id = user_id;

            return user;
        }

        public void UpdateUser(string user_id, string name, string email, int type_id)
        {
            bool updated = DAL.User.UpdateUserInfo(user_id, name, email, type_id);
            if (updated)
            {
                Models.Message.DisplayMessage("success", "usuario editado com sucesso");
            }
            else
            {
                Models.Message.DisplayMessage("danger", "nao foi possivel editar usuario");
            }
        }
    }
}