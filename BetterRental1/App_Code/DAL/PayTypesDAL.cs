using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using BLL;
using System.Data.SqlClient;



namespace DAL
{
    public class PayTypesDAL
    {
        public static void Save(PayTypes Tmp)
        {
            string Sql;
            if (Tmp.Ptid == -1)
            {
                Sql = $"insert into T_PayTypes(PayTaype,AddDate,Remarks,CompanyCode,Status) " +
                    $"values(@PayTaype,@AddDate,@Remarks,@CompanyCode,@Status)";
            }
            else
            {
                Sql = $"Update T_PayTypes set " +
                    $"PayTaype=@PayTaype," +
                    $"AddDate=@AddDate," +
                     $"Remarks=@Remarks," +
                     $"CompanyCode=@CompanyCode," +
                    $"Status=@Status  Where Ptid=@Ptid";
            }
            DbContext Db = new DbContext();
            var Obj = new
            {

                Ptid = Tmp.Ptid,
                PayTaype = Tmp.PayTaype,
                AddDate = Tmp.AddDate,
                Remarks = Tmp.Remarks,
                CompanyCode = Tmp.CompanyCode,
                Status = Tmp.Status,
            };


            var lstParam = DbContext.CreateParameters(Obj);





            Db.ExecuteNonQuery(Sql, lstParam);

            
            Db.Close();

        }
        public static List<PayTypes> GetAll()
        {
            List<PayTypes> payTypesList = new List<PayTypes>();
            string Sql = "Select * from T_PayTypes";
            DbContext Db = new DbContext();
            DataTable Dt = Db.Execute(Sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                PayTypes tmp = new PayTypes()
                {
                    Ptid = int.Parse(Dt.Rows[i]["Ptid"].ToString()),
                    PayTaype = Dt.Rows[i]["PayTaype"].ToString(),
                    AddDate = DateTime.Parse(Dt.Rows[i]["AddDate"].ToString()),
                    Remarks = Dt.Rows[i]["Remarks"].ToString(),
                    CompanyCode = int.Parse(Dt.Rows[i]["CompanyCode"].ToString()),
                    Status = bool.Parse(Dt.Rows[i]["Status"].ToString()),

                };
                payTypesList.Add(tmp);
            }
            Db.Close();
            return payTypesList;
        }
        public static PayTypes GetById(int Id)
        {
            PayTypes tmp = null;
            string Sql = $"Select * from T_PayTypes Where Ptid = {Id}";
            DbContext Db = new DbContext();
            DataTable Dt = Db.Execute(Sql);
            if (Dt.Rows.Count > 0)
            {
                tmp = new PayTypes()
                {
                    Ptid = int.Parse(Dt.Rows[0]["Ptid"].ToString()),
                    PayTaype = Dt.Rows[0]["PayTaype"].ToString(),
                    AddDate = DateTime.Parse(Dt.Rows[0]["AddDate"].ToString()),
                    Remarks = Dt.Rows[0]["Remarks"].ToString(),
                    CompanyCode = int.Parse(Dt.Rows[0]["CompanyCode"].ToString()),
                    Status = bool.Parse(Dt.Rows[0]["Status"].ToString()),

                };

            }
            Db.Close();
            return tmp;
        }
        public static int DeleteById(int Id)
        {
            string Sql = $"Delete from  T_PayTypes Where Ptid = {Id}";
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