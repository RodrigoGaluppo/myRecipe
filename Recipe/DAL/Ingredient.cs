using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Recipe.DAL
{
    public class Ingredient: DefaultDAL
    {
        public static Models.Ingredient[] ListAll()
        {
            DataTable dt = new DataTable();
            Models.Ingredient[] ingredients;

            try
            {
                using (SqlConnection con = new SqlConnection(dbString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("ListIngredients", con);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(dt);
                }
            }
            catch (Exception)
            {
                return default;
            }

            ingredients = new Models.Ingredient[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                Models.Ingredient ingredient = new Models.Ingredient();

                ingredient.id = (int)row["id"];
                ingredient.name = (string)row["name"];

                ingredients[i] = ingredient;
            }


            return ingredients;
        }

        public static bool DeleteIngredient(int id)
        {
            DataTable dt = new DataTable();


            try
            {
                using (SqlConnection con = new SqlConnection(dbString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("DeleteIngredient", con);
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

        public static bool CreateIngredient(string name)
        {
            DataTable dt = new DataTable();


            try
            {
                using (SqlConnection con = new SqlConnection(dbString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("CreateIngredients", con);
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