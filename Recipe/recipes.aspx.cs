using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using  Recipe.DAL;
using Recipe.Models;
namespace Recipe
{
    public partial class Recipes : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
        }

        public static Models.Recipe[] displayList()
        {
            Models.Recipe[] recipes = DAL.Recipe.ListAll();

            return recipes;
        }

        public static Models.Recipe[] search(string filter)
        {
            Models.Recipe[] recipes = DAL.Recipe.ListAllByFilter(filter);

            return recipes;
        }
    }
}