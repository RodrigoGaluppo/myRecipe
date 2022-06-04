using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Recipe.DAL
{
    public class Measure : DefaultDAL
    {
        public static Models.Measure[] ListAll()
        {
            DataTable dt = new DataTable();
            Models.Measure[] measures;

            try
            {
                using (SqlConnection con = new SqlConnection(dbString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("ListMeasures", con);
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

            measures = new Models.Measure[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                Models.Measure measure = new Models.Measure();

                measure.id = (int)row["id"];
                measure.name = (string)row["name"];

                measures[i] = measure;
            }


            return measures;
        }

        public static bool DeleteMeasure(int id)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(dbString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("DeleteMeasure", con);
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

        public static bool CreateMeasure(string name)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(dbString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("CreateMeasure", con);
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