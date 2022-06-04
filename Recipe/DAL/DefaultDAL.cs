using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Recipe.DAL
{
    public class DefaultDAL
    {
        public static readonly string dbString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

        public static string Img_Url_Builder(string img_name)
        {
            return "https://app-myrecipe.s3.eu-west-2.amazonaws.com/" + img_name;
        }
    }
}