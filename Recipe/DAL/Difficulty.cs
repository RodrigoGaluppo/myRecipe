using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Recipe.DAL
{
    public class Difficulty:DefaultDAL
    {
        public static Models.Difficulty[] ListAll()
        {
            DataTable dt = new DataTable();
            Models.Difficulty[] difficulties;

            try
            {
                using (SqlConnection con = new SqlConnection(dbString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("ListDifficulty", con);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(dt);
                }
            }
            catch (Exception)
            {

            }

            difficulties = new Models.Difficulty[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                Models.Difficulty Difficulty = new Models.Difficulty();

                Difficulty.id = (int)row["difficulty_id"];
                Difficulty.name = (string)row["name"];

                difficulties[i] = Difficulty;
            }


            return difficulties;
        }
    }
}