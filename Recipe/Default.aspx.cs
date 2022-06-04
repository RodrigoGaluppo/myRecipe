using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Recipe.DAL;
using Recipe.Models;

namespace Recipe
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public static Models.Recipe[] listTopRecipes()
        {
            Models.Recipe[] recipes = DAL.Recipe.ListTopRecipes();
            return recipes;
        }

        
    }
}


