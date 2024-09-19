using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using System.Data;
using Data;
using System.Data.SqlClient;

namespace DAL
{
    public class TypeExpensesDAL
    {
        public static void Save(TypeExpenses Tmp)
        {
            string Sql;
            if (Tmp.TEid == -1)
            {
                Sql = $"insert into T_typeExpenses(TypeExpense,AddDate,Remarks,Status,CompanyCode) " +
                    $"values(@TypeExpense,@AddDate,@Remarks,@Status,@CompanyCode)";
            }
            else
            {
                Sql = $"Update T_typeExpenses set " +
                       $"TypeExpense=@TypeExpense," +
                        $"AddDate = @AddDate ," +
                      $"Remarks=@Remarks," +
                       $"Status=@Status," +


                        $"CompanyCode=@CompanyCode      where TEid=@TEid";

            }
            DbContext Db = new DbContext();
            var Obj = new
            {
                
                TEid = Tmp.TEid,
                TypeExpense = Tmp.TypeExpense,
                Remarks = Tmp.Remarks,
                CompanyCode = Tmp.CompanyCode,
                AddDate = Tmp.AddDate,
                Status = Tmp.Status,
            };


            var lstParam = DbContext.CreateParameters(Obj);





            Db.ExecuteNonQuery(Sql, lstParam);

           
            Db.Close();

        }
        public static List<TypeExpenses> GetAll()
        {
            List<TypeExpenses> TypeExpensesList = new List<TypeExpenses>();
            string Sql = "Select * from T_typeExpenses";
            DbContext Db = new DbContext();
            DataTable Dt = Db.Execute(Sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                TypeExpenses tmp = new TypeExpenses()
                {
                    TEid = int.Parse(Dt.Rows[i]["TEid"].ToString()),
                    TypeExpense = Dt.Rows[i]["TypeExpense"].ToString(),
                    Status = bool.Parse(Dt.Rows[i]["Status"].ToString()),
                    Remarks = Dt.Rows[i]["Remarks"].ToString(),
                    AddDate = DateTime.Parse(Dt.Rows[i]["AddDate"].ToString()),
                    CompanyCode = int.Parse(Dt.Rows[i]["CompanyCode"].ToString()),
                };
                TypeExpensesList.Add(tmp);
            }
            Db.Close();
            return TypeExpensesList;
        }
        public static TypeExpenses GetById(int Id)
        {
            TypeExpenses tmp = null;
            string Sql = $"Select * from T_typeExpenses Where TEid = {Id}";
            DbContext Db = new DbContext();
            DataTable Dt = Db.Execute(Sql);
            if (Dt.Rows.Count > 0)
            {
                tmp = new TypeExpenses()
                {
                    TEid = int.Parse(Dt.Rows[0]["TEid"].ToString()),
                    TypeExpense = Dt.Rows[0]["TypeExpense"].ToString(),
                    Status = bool.Parse(Dt.Rows[0]["Status"].ToString()),
                    Remarks = Dt.Rows[0]["Remarks"].ToString(),
                    AddDate = DateTime.Parse(Dt.Rows[0]["AddDate"].ToString()),
                    CompanyCode = int.Parse(Dt.Rows[0]["CompanyCode"].ToString()),
                };

            }
            Db.Close();
            return tmp;
        }
        public static int DeleteById(int Id)
        {
            string Sql = $"Delete from  T_typeExpenses Where TEid = {Id}";
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