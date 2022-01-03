using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TestWebAPI.Database
{
    public class Database
    {
        //public DataTable ExecuteQuery(string query)
        //{
        //    string SQLConnectionString = ConfigurationManager.ConnectionStrings["connectPhoneManagement"].ConnectionString;
        //    DataTable data = new DataTable();
        //    using (SqlConnection connection = new SqlConnection(SQLConnectionString))
        //    {
        //        connection.Open();
        //        SqlCommand command = new SqlCommand(query, connection);
        //        SqlDataAdapter adapter = new SqlDataAdapter(command);
        //        adapter.Fill(data);
        //        connection.Close();
        //    }
        //    return data;
        //}
        public static DataTable ReadTable(string query)
        {
            try
            {
                DataTable tableResult = new DataTable();



                //connect to csdl
                string SQLStringconnect = ConfigurationManager.ConnectionStrings["connectPhoneManagement"].ConnectionString;
                SqlConnection connection = new SqlConnection(SQLStringconnect);



                connection.Open();



                SqlCommand sqlCmd = connection.CreateCommand();
                sqlCmd.Connection = connection;
                sqlCmd.CommandText = query;
                sqlCmd.CommandType = CommandType.Text;



                



                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCmd;
                sqlDA.Fill(tableResult);



                connection.Close();



                return tableResult;
            }
            catch
            {
                return null;
            }
        }
    }

}