using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;

namespace Data
{
    public class DbContext
    {
        // מחרוזת חיבור למסד הנתונים
        public string Connstr { get; set; }

        // אובייקט החיבור למסד הנתונים
        public SqlConnection Conn { get; set; }

        // אובייקט הפקודה לביצוע שאילתות
        public SqlCommand Cmd { get; set; }

        // בנאי המגדיר את החיבור למסד הנתונים
        public DbContext()
        {
            Connstr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
           

            Conn = new SqlConnection();
            Conn.ConnectionString = Connstr;
            Open();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;


        }

        // שיטה לביצוע שאילתה שאינה מחזירה נתונים (INSERT, UPDATE, DELETE)
        public int ExecuteNonQuery(string Sql, List<SqlParameter> lst=null)
        {
            int RecCount = 0;
            
            Cmd.CommandText = Sql;
            if (lst != null)
            {
                for(int i = 0; i < lst.Count; i++)
                    Cmd.Parameters.Add(lst[i]);

            }
            RecCount=Cmd.ExecuteNonQuery();
            Cmd.Dispose();
             return RecCount;

        }     

        // שיטה לביצוע שאילתה שמחזירה נתונים כ-DataTable
        public DataTable Execute(string Sql, int CmdType=1)
        {
                
            Cmd.CommandText = Sql;
            DataTable Dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            if (CmdType == 2)
                Cmd.CommandType = CommandType.StoredProcedure;

            Da.SelectCommand = Cmd;
            Da.Fill(Dt);
            Cmd.Dispose();
            return Dt;
        }

        // שיטה ליצירת רשימת פרמטרים מאובייקט
        public static List<SqlParameter> CreateParameters (object ParametersObject)
        {
            var Parameters=new List<SqlParameter>();

            var arr= ParametersObject.GetType().GetProperties(BindingFlags.Public|BindingFlags.Instance);

            for(int i = 0; i < arr.Length; i++)
            {
                Parameters.Add(new SqlParameter(arr[i].Name, arr[i].GetValue(ParametersObject,null)));
            }
            return Parameters;
        }

        // שיטה לביצוע שאילתה שמחזירה ערך יחיד
        public object ExecuteScalar(string sql)
        {
            Cmd.CommandText = sql;
            return Cmd.ExecuteScalar();

        }


        public void Open()
        {
            Conn.Open();
        }
        public void Close()
        {
            Conn.Close();




        }

    }
}