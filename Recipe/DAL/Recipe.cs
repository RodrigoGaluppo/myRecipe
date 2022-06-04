using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Recipe.Models;

namespace Recipe.DAL
{
    class Recipe : DefaultDAL
    {
      
        // list all the recipes for the home page
        public static Models.Recipe[] ListAll()
         {
            DataTable dt = new DataTable();
            Models.Recipe[] recipes;

            try
            {
                using (SqlConnection con = new SqlConnection(dbString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("List", con);
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
            recipes = new Models.Recipe[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                Models.Recipe recipe = new Models.Recipe();
                recipe.recipe_id = (int)row["recipe_id"];
                recipe.name = (string)row["name"];
                recipe.number_of_people = (int)row["number_of_people"];
                recipe.img_url = Img_Url_Builder((string)row["img_url"]);
                recipe.preparation_time = (int)row["preparation_time"];
                recipe.category = (string)row["category"];
                recipes[i] = recipe;
            }
            return recipes;
         }

        // list all the recipes selecting them by the specified filter
        public static Models.Recipe[] ListAllByFilter(string filter)
        {
            DataTable dt = new DataTable();
            Models.Recipe[] recipes;

            filter = String.Concat("%", filter, "%");

            try
            {
                using (SqlConnection con = new SqlConnection(dbString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SearchRecipeByFilter", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@filter", SqlDbType.NVarChar).Value = filter;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(dt);
                }


            }
            catch (Exception)
            {
                return default;
            }
            recipes = new Models.Recipe[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                Models.Recipe recipe = new Models.Recipe();
                recipe.recipe_id = (int)row["recipe_id"];
                recipe.name = (string)row["name"];
                recipe.number_of_people = (int)row["number_of_people"];
                recipe.img_url = Img_Url_Builder((string)row["img_url"]);
                recipe.preparation_time = (int)row["preparation_time"];
                recipe.category = (string)row["category"];
                recipes[i] = recipe;
            }
            return recipes;
        }

        // list all the recipes that user has on his favorites list 
        public static Models.Recipe[] ListLikedByuserId(string user_id)
        {
            DataTable dt = new DataTable();
            Models.Recipe[] recipes;


            try
            {
                using (SqlConnection con = new SqlConnection(dbString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("ListLikedRecipes", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@user_id", SqlDbType.NVarChar).Value = user_id;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(dt);
                }


            }
            catch (Exception)
            {
                return default;
            }
            recipes = new Models.Recipe[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                Models.Recipe recipe = new Models.Recipe();
                recipe.recipe_id = (int)row["recipe_id"];
                recipe.name = (string)row["name"];
                recipe.number_of_people = (int)row["number_of_people"];
                recipe.img_url = Img_Url_Builder((string)row["img_url"]);
                recipe.preparation_time = (int)row["preparation_time"];
                recipe.category = (string)row["category"];
                recipes[i] = recipe;
            }
            return recipes;
        }

        // list the recipes that are owned by the specified user
        public static Models.Recipe[] ListByUserId(string user_id)
        {
            DataTable dt = new DataTable();
            Models.Recipe[] recipes;
            
                using (SqlConnection con = new SqlConnection(dbString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SelectRecipesByUserId", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@id", SqlDbType.NVarChar).Value = user_id;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(dt);
                }
            

            recipes = new Models.Recipe[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                Models.Recipe recipe = new Models.Recipe();
                recipe.recipe_id = (int)row["recipe_id"];
                recipe.name = (string)row["name"];
                recipe.number_of_people = (int)row["number_of_people"];
                recipe.img_url = Img_Url_Builder((string)row["img_url"]);
                recipe.preparation_time = (int)row["preparation_time"];
                recipe.category = (string)row["category"];
                recipes[i] = recipe;
            }


            return recipes;
        }

        // list all the recipes for the dashboard on admin´s backoffice
        public static Models.Recipe[] ListForDashBoard()
        {
            DataTable dt = new DataTable();
            Models.Recipe[] recipes;
            using (SqlConnection con = new SqlConnection(dbString))
            {
                con.Open();
                SqlCommand command = new SqlCommand("ListRecipes", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dt);
            }

            recipes = new Models.Recipe[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                Models.Recipe recipe = new Models.Recipe();
                recipe.recipe_id = (int)row["recipe_id"];
                recipe.name = (string)row["name"];
                recipe.number_of_people = (int)row["number_of_people"];
                recipe.img_url = Img_Url_Builder((string)row["img_url"]);
                recipe.preparation_time = (int)row["preparation_time"];
                recipe.category = (string)row["category"];
                recipe.active = (bool)row["active"];
                recipes[i] = recipe;
            }


            return recipes;
        }

        // select recipe by ID for users to see
        public static Models.Recipe SelectRecipeById(int id)
        {
            DataTable dt = new DataTable();
            Models.Recipe Recipe = new Models.Recipe();
            try
            {
                using (SqlConnection con = new SqlConnection(dbString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SelectRecipeById", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(dt);
                }

            }
            catch (Exception)
            {
                return Recipe;
            }


            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                Recipe.name = (string)row["name"];
                Recipe.img_url = Img_Url_Builder((string)row["img_url"]);
                Recipe.description = (string)row["description"];
                Recipe.category = (string)row["category"];
                Recipe.difficulty = (string)row["difficulty"];
                Recipe.preparation_time = (int)row["preparation_time"];
                Recipe.number_of_people = (int)row["number_of_people"];
                Recipe.preparation_method = (string)row["preparation_method"];

            }
            return Recipe;
        }

        // select recipe by the specified ID with all data, used for dashboard
        public static Models.Recipe SelectRecipeByIdDashBoard(int id)
        {
            DataTable dt = new DataTable();
            Models.Recipe Recipe = new Models.Recipe();
            try
            {
                using (SqlConnection con = new SqlConnection(dbString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SelectRecipeByIdDashBoard", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(dt);
                }
            }
            catch (Exception)
            {
                return Recipe;
            }

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                Recipe.name = (string)row["name"];
                Recipe.img_url = Img_Url_Builder((string)row["img_url"]);
                Recipe.description = (string)row["description"];
                Recipe.category = (string)row["category"];
                Recipe.difficulty = (string)row["difficulty"];
                Recipe.preparation_time = (int)row["preparation_time"];
                Recipe.number_of_people = (int)row["number_of_people"];
                Recipe.preparation_method = (string)row["preparation_method"];
                Recipe.user_id = (string)row["user_id"];
                Recipe.active = (bool)row["active"];
            }
            return Recipe;
        }


        /*Create Recipe*/
        public static bool CreateRecipe( string name, string user_id, string description, int preparation_time, int category_id,
            int difficulty_id, string img_url, int number_of_people, string preparation_method, Models.IngredientList[] ingredients_list, bool active = true)
        {
            DataTable dt = new DataTable();
            int getid;
            try
            {
                using (SqlConnection con = new SqlConnection(dbString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("CreateRecipe", con);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                    command.Parameters.Add("@user_id", SqlDbType.NVarChar).Value = user_id;
                    command.Parameters.Add("@description", SqlDbType.Text).Value = description;
                    command.Parameters.Add("@preparation_time", SqlDbType.Int).Value = preparation_time;
                    command.Parameters.Add("@category_id", SqlDbType.Int).Value = category_id;
                    command.Parameters.Add("@difficulty_id", SqlDbType.Int).Value = difficulty_id;
                    
                    command.Parameters.Add("@img_url", SqlDbType.NText).Value = img_url ;
                    command.Parameters.Add("@number_of_people", SqlDbType.Int).Value = number_of_people;
                    command.Parameters.Add("@preparation_method", SqlDbType.Text).Value = preparation_method;
                    command.Parameters.Add("@active", SqlDbType.Bit).Value = active;


                    command.ExecuteNonQuery();

                    //dataAdapter.Fill(dt);
                }
            }
            catch (Exception)
            {
                return false;
            }

            DataTable Ndt = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(dbString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SelectMostRecentItem", con);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(Ndt);

                    DataRow row = Ndt.Rows[0];
                    getid = (int)row["recipe_id"];
                }
            }
            catch (Exception)
            {
                return false;
            }

            DataTable N2dt = new DataTable();

            foreach (Models.IngredientList ingredient in  ingredients_list)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(dbString))
                    {
                        con.Open();
                        SqlCommand command = new SqlCommand("CreateIngredientToRecipe", con);
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@quantity", SqlDbType.Float).Value = ingredient.quantity;
                        command.Parameters.Add("@recipe_id", SqlDbType.Int).Value = getid;
                        command.Parameters.Add("@measure_id", SqlDbType.Int).Value = ingredient.measure_id;
                        command.Parameters.Add("@ingredient_id", SqlDbType.Int).Value = ingredient.ingredient_id;

                        SqlDataAdapter dataAdapter = new SqlDataAdapter();
                        dataAdapter.SelectCommand = command;
                        dataAdapter.Fill(N2dt);
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            return true;
        }

        /* update recipe status */
        public static bool UpdateRecipe(int id,bool active)
        {
    
        DataTable dt = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(dbString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("UpdateRecipe", con);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@recipe_id", SqlDbType.Int).Value = id;
                    command.Parameters.Add("@active", SqlDbType.Bit).Value = active;

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

        public static Models.IngredientList[] ListIngredientsByRecipeId(int recipe_id)
        {
            DataTable dt = new DataTable();

            Models.IngredientList[] ingredients;

            using (SqlConnection con = new SqlConnection(dbString))
            {
                con.Open();
                SqlCommand command = new SqlCommand("SelectIngredientsListByRecipeId", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@recipe_id", SqlDbType.Int).Value = recipe_id;
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dt);
            }

            ingredients = new Models.IngredientList[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Models.IngredientList ing = new Models.IngredientList();
                DataRow row = dt.Rows[i];
                
                ing.ingredient = (string)row["ingredient"];
                ing.measure = (string)row["measure"];
                ing.quantity = (float)((double)row["quantity"]);

                ingredients[i] = ing;
            }

            return ingredients;
        }

        public static Models.Recipe[] ListTopRecipes()
        {
            DataTable dt = new DataTable();
            Models.Recipe[] recipes;
            using (SqlConnection con = new SqlConnection(dbString))
            {
                con.Open();
                SqlCommand command = new SqlCommand("ListFirst10Recipes", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dt);
            }
            recipes = new Models.Recipe[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                Models.Recipe recipe = new Models.Recipe();
                recipe.recipe_id = (int)row["recipe_id"];
                recipe.name = (string)row["name"];
                recipe.number_of_people = (int)row["number_of_people"];
                recipe.img_url = Img_Url_Builder((string)row["img_url"]);
                recipe.preparation_time = (int)row["preparation_time"];
                recipe.category = (string)row["category"];
                
                recipe.averageRate = CalculateRateAverage(recipe.recipe_id);

                /* ordered insertion */
                int idx;
                int idx2;

                for ( idx = 0; idx < i; idx++)
                {
                    if (recipes[idx].averageRate < recipe.averageRate)
                        break;
                }

                for (idx2 = i - 1; idx2 >= idx; idx2--)
                {
                    recipes[idx2 + 1] = recipes[idx2];
                }

                recipes[idx] = recipe;
            }

            return recipes;
        }

        public static Models.Rate[] ListRates(int recipe_id)
        {
            DataTable dt = new DataTable();
            Models.Rate[] rates;

            try
            {
                using (SqlConnection con = new SqlConnection(dbString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("ListEvalution", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("recipe_id", SqlDbType.Int).Value = recipe_id;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(dt);
                }


            }
            catch (Exception)
            {
                return default;
            }
            rates = new Models.Rate[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                Models.Rate rate = new Models.Rate();
                rate.comment = (string)row["comment"];
                rate.user_name = (string)row["name"];
                rate.rate = (float)Convert.ToDouble(row["rate"]);
                rates[i] = rate;
            }
            return rates;
        }

        public static float CalculateRateAverage(int id)
        {
            DataTable dt = new DataTable();
            float rate = 0;
            using (SqlConnection con = new SqlConnection(dbString))
            {
                con.Open();
                SqlCommand command = new SqlCommand("GetRatesByRecipeId", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("id", SqlDbType.Int).Value = id;
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dt);

            }

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];

                double c = (double)row["rate"];

                rate += (float)c;
            }


            if(dt.Rows.Count > 0)
                rate /= dt.Rows.Count;

            return rate;
        }

        
    }
}