using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Data;
using System.Data.SqlClient;
using BLL;


namespace DAL
{
    public class ExpensesDAL
    {
        public static void Save(Expenses Tmp)
        {
            string Sql;
            if (Tmp.Teid == -1)
            {
                Sql = $"insert into T_expenses(Amount,Exdate,AddDate,Remarks,Exid,CompanyCode,Status) " +
                    $"values(@Amount,@Exdate,@AddDate,@Remarks,@Exid,@CompanyCode,@Status)";
            }
            else
            {
                Sql = $"Update T_expenses set " +
                      $"Amount=@Amount," +
                      $"Exdate=@Exdate," +                     
                      $"AddDate=@AddDate," +
                      $"Remarks=@Remarks," +
                      $"Exid=@Exid, " +
                      $"CompanyCode=@CompanyCode," +
                      $"Status=@Status  Where Teid=@Teid";

            }
            DbContext Db = new DbContext();
            var Obj = new
            {

                Amount = Tmp.Amount,
                Teid = Tmp.Teid,
                Exdate = Tmp.Exdate,
                AddDate = Tmp.AddDate,
                Remarks = Tmp.Remarks,
                Exid = Tmp.Exid,
                CompanyCode = Tmp.CompanyCode,
                Status = Tmp.Status,
            };


            var lstParam = DbContext.CreateParameters(Obj);





            Db.ExecuteNonQuery(Sql, lstParam);

            Db.Close();


        }
        public static List<Expenses> GetAll()
        {
            List<Expenses> ExpensesList = new List<Expenses>();
            string Sql = "Select * from T_expenses";
            DbContext Db = new DbContext();
            DataTable Dt = Db.Execute(Sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Expenses tmp = new Expenses()
                {
                    Amount = float.Parse(Dt.Rows[i]["Exid"].ToString()),
                    Teid = int.Parse(Dt.Rows[i]["Teid"].ToString()),
                    Exdate = DateTime.Parse(Dt.Rows[i]["Exdate"].ToString()),
                    AddDate = DateTime.Parse(Dt.Rows[i]["AddDate"].ToString()),
                    Remarks = Dt.Rows[i]["Remarks"].ToString(),
                    Exid = int.Parse(Dt.Rows[i]["Exid"].ToString()),
                    CompanyCode = int.Parse(Dt.Rows[i]["CompanyCode"].ToString()),
                    Status = bool.Parse(Dt.Rows[i]["Status"].ToString()),
                };
                ExpensesList.Add(tmp);
            }
            Db.Close();
            return ExpensesList;
        }
        public static Expenses GetById(int Id)
        {
            Expenses tmp = null;
            string Sql = $"Select * from T_expenses Where Teid = {Id}";
            DbContext Db = new DbContext();
            DataTable Dt = Db.Execute(Sql);
            if (Dt.Rows.Count > 0)
            {
                tmp = new Expenses()
                {
                    Amount = float.Parse(Dt.Rows[0]["Exid"].ToString()),
                    Teid = int.Parse(Dt.Rows[0]["Teid"].ToString()),
                    Exdate = DateTime.Parse(Dt.Rows[0]["Exdate"].ToString()),
                    AddDate = DateTime.Parse(Dt.Rows[0]["AddDate"].ToString()),
                    Remarks = Dt.Rows[0]["Remarks"].ToString(),
                    Exid = int.Parse(Dt.Rows[0]["Exid"].ToString()),
                    CompanyCode = int.Parse(Dt.Rows[0]["CompanyCode"].ToString()),
                    Status = bool.Parse(Dt.Rows[0]["Status"].ToString()),
                };

            }
            Db.Close();
            return tmp;
        }
        public static int DeleteById(int Id)
        {
            string Sql = $"Delete from  T_expenses Where Teid = {Id}";
            DbContext Db = new DbContext();
            int Total = Db.ExecuteNonQuery(Sql);
            Db.Close();
            if (Total > 0)
                return 1;
            else
                return -1;
        }

    }
}