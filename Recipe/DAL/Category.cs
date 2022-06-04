using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Recipe.DAL
{
    public class Category:DefaultDAL
    {
        public static Models.Category[] ListAll()
        {
            DataTable dt = new DataTable();
            Models.Category[] categories;

            try
            {
                using (SqlConnection con = new SqlConnection(dbString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("ListCategories", con);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(dt);
                }
            }
            catch (Exception)
            {
                
            }

            categories = new Models.Category[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                Models.Category category = new Models.Category();

                category.id = (int)row["category_id"];
                category.name = (string)row["name"];

                categories[i] = category;
            }


            return categories;
        }

        public static bool DeleteCategory(int id)
        {
            DataTable dt = new DataTable();
      

            try
            {
                using (SqlConnection con = new SqlConnection(dbString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("DeleteCategory", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(dt);
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public static bool CreateCategory(string name)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(dbString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("CreateCategory", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(dt);
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}