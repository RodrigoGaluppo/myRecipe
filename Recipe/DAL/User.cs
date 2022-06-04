using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Recipe.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Recipe.DAL
{
    public class User : DefaultDAL
    {

        public static string Login(string email,string password)
        {
       
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(dbString))
                {


                    con.Open();

                    



                    SqlCommand command = new SqlCommand("Login", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
                    command.Parameters.Add("@password", SqlDbType.NVarChar).Value = Models.Encrypter.Encrypt(password);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(dt);
                    
                }
            }
            catch (Exception)
            {
                return "";
            }

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                return (string)row["user_id"];
            }

            return "" ;
        }

        public static string LoginAdmin(string email, string password)
        {

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(dbString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("LoginAdmin", con);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
                    command.Parameters.Add("@password", SqlDbType.NVarChar).Value = Models.Encrypter.Encrypt(password);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(dt);
                }
            }
            catch (Exception)
            {
                return "";
            }

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                return (string)row["user_id"];
            }

            return "";
        }


        public static bool CreateUser(string name,string email, string password,int type_id = 1)
        {
            DataTable dt = new DataTable();

            try
            {
                if (VerifyEmailExists(email)) // verify if email exists
                {
                    return false;
                }

                using (SqlConnection con = new SqlConnection(dbString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("CreateUser", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
                    command.Parameters.Add("@password", SqlDbType.NVarChar).Value = Models.Encrypter.Encrypt(password);
                    command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                    command.Parameters.Add("@type", SqlDbType.Int).Value = type_id;
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

        private static bool VerifyEmailExists(string email)
        {
            DataTable dt = new DataTable();

            try
            {

                using (SqlConnection con = new SqlConnection(dbString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("EmailExists", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(dt);
                }
            }
            catch (Exception)
            {
                return false;
            }
            
            if(dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Models.User SelectUserById(string id)
        {
            DataTable dt = new DataTable();
            Models.User user = new Models.User();
            try
            {

                using (SqlConnection con = new SqlConnection(dbString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SelectUserById", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(dt);
                }
            }
            catch (Exception)
            {
                return user;
            }

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                user.user_type = (string)row["user_type"];
                user.name = (string)row["name"];
                user.email = (string)row["email"];
            }
            return user;
        }

        public static bool CreateReview(string comment, float rate, int recipe_id,string user_id)
        {
            DataTable dt = new DataTable();

            if (UserAlreadyEvaluated(user_id, recipe_id))
                return false;

            try
            {

                using (SqlConnection con = new SqlConnection(dbString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("CreateEvaluation", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@userID", SqlDbType.NVarChar).Value = user_id;
                    command.Parameters.Add("@recipeID", SqlDbType.Int).Value = recipe_id;
                    command.Parameters.Add("@NComment", SqlDbType.NVarChar).Value = comment;
                    command.Parameters.Add("@Rate", SqlDbType.Float).Value = rate;
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

        private static bool UserAlreadyEvaluated(string user_id,int recipe_id)
        {
            DataTable dt = new DataTable();


            try
            {
                using (SqlConnection con = new SqlConnection(dbString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("VerifyUserAlreadyEvaluated", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@user_id", SqlDbType.NVarChar).Value = user_id;
                    command.Parameters.Add("@recipe_id", SqlDbType.Int).Value = recipe_id;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(dt);
                }
            }
            catch (Exception)
            {
                return true;
            }
            

            return  dt.Rows.Count > 0;
        }

        public static bool UpdateUserInfo(string user_id,string name, string email, int type_id = 1)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(dbString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("UpdateUserInfo", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@id", SqlDbType.NVarChar).Value = user_id;
                    command.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
                    command.Parameters.Add("@type_id", SqlDbType.Int).Value = type_id;
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
        

        public static bool RemoveLikeFromRecipe(string user_id, int recipe_id)
        {

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(dbString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("RemoveLike", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@user_id", SqlDbType.NVarChar).Value = user_id;
                    command.Parameters.Add("@recipe_id", SqlDbType.Int).Value = recipe_id;
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

        public static bool AddLikeToRecipe(string user_id,int recipe_id)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(dbString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("CreateLike", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@user_id", SqlDbType.NVarChar).Value = user_id;
                    command.Parameters.Add("@recipe_id", SqlDbType.Int).Value = recipe_id;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(dt);
                }
            }
            catch(Exception)
            {
                return false;
            }
            

            return true;
        }

        public static Models.User[] ListUsers()
        {
            DataTable dt = new DataTable();
            Models.User[] users;
            users = new Models.User[dt.Rows.Count];
            try
            {
                using (SqlConnection con = new SqlConnection(dbString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("ListUsers", con);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(dt);
                }
            }
            catch (Exception)
            {
                return users;
            }

            users = new Models.User[dt.Rows.Count];

            if (dt.Rows.Count > 0)
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    Models.User user = new Models.User();
                    user.id = (string)row["user_id"];
                    user.name = (string)row["name"];
                    user.email = (string)row["email"];
                    user.user_type = (string)row["user_type"];
                    users[i] = user;
                }
  
            }
            return users;
        }
    }
}