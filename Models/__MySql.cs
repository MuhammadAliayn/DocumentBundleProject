using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace InPlace4.Models
{
    public class __MySql
    {
        private bool __Ready;
        public bool Ready
        {
            get { return __Ready; }
        }

        private MySqlConnection Conn;

        private string __DatabaseName;
        public string DatabaseName
        {
            get { return __DatabaseName; }
        }

        public __MySql(string DBName)
        {
            try
            {
                Conn = new MySqlConnection();
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                __Ready = TestConnection();
                if (__Ready)
                {
                    __DatabaseName = Conn.ConnectionString.Substring(Conn.ConnectionString.IndexOf("database=") + "database=".Length);
                    __DatabaseName = __DatabaseName.Substring(0, __DatabaseName.IndexOf(";"));
                }
            }
            catch (Exception e)
            {

            }
        }

        public bool TestConnection()
        {
            bool Result = false;
            try
            {
                if (Conn.State == ConnectionState.Open) Conn.Close();
                Conn.Open();
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                    Result = true;
                }
            }
            catch (Exception e)
            {
                Conn.Close();
            }
            return Result;
        }

        public bool ExecuteQuery(string Query, DataSet DS = null, string TableName = "Table")
        {
            bool Result = false;

            try
            {
                Conn.Open();
                if (Conn.State == ConnectionState.Open)
                {
                    MySqlCommand Cmd = new MySqlCommand(Query, Conn);
                    Cmd.CommandType = CommandType.Text;

                    if (DS == null) Cmd.ExecuteNonQuery();
                    else
                    {
                        MySqlDataAdapter Adp = new MySqlDataAdapter(Cmd);
                        if (string.IsNullOrEmpty(TableName)) Adp.Fill(DS);
                        else Adp.Fill(DS, TableName);
                    }

                    Conn.Close();
                    Result = true;
                }
            }
            catch (Exception e)
            {
                Conn.Close();
            }


            return Result;
        }
    }
}