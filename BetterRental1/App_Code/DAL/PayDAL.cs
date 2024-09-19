using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using System.Data.SqlClient;
using BLL;
using System.Data;


namespace DAL
{
    public class PayDAL
    {
        public static void Save(Pay Tmp)
        {
            string Sql;
            if (Tmp.Paid == -1)
            {
                Sql = $"insert into T_pay(Padata,PaySum,Ptid,Status,AddDate,Remarks,Caid,Oid,CompanyCode) " +
                      $"values(@Padata,@PaySum,@Ptid,@Status,@AddDate,@Remarks,@Caid,@Oid,@CompanyCode)";
            }
            else
            {
                Sql = $"Update T_pay set " +
                      $"Padata=@Padata," +
                      $"PaySum=@PaySum," +
                      $"Ptid=@Ptid," +                    
                      $"Status=@Status ," +                  
                      $"AddDate=@AddDate," +
                      $"Remarks=@Remarks," +
                      $"Caid=@Caid," +
                      $"Oid=@Oid," +
                      $"CompanyCode=@CompanyCode  Where Paid=@Paid";
            }
            DbContext Db = new DbContext();
            var Obj = new
            {

                Paid = Tmp.Paid,
                Padata = Tmp.Padata,
                PaySum = Tmp.PaySum,
                Ptid = Tmp.Ptid,
                Status = Tmp.Status,
                AddDate = Tmp.AddDate,
                Remarks = Tmp.Remarks,
                Caid = Tmp.Caid,
                Oid = Tmp.Oid,     
                CompanyCode = Tmp.CompanyCode,
               
            };


            var lstParam = DbContext.CreateParameters(Obj);





            Db.ExecuteNonQuery(Sql, lstParam);

            Db.Close();

        }
        public static List<Pay> GetAll()
        {
            List<Pay> payList = new List<Pay>();
            string Sql = "Select * from T_pay";
            DbContext Db = new DbContext();
            DataTable Dt = Db.Execute(Sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Pay tmp = new Pay()
                {
                    Paid = int.Parse(Dt.Rows[i]["Paid"].ToString()),
                    Padata = DateTime.Parse(Dt.Rows[i]["Padata"].ToString()),
                    PaySum = int.Parse(Dt.Rows[i]["PaySum"].ToString()),
                    Ptid = int.Parse(Dt.Rows[i]["Ptid"].ToString()),
                    Status = bool.Parse(Dt.Rows[i]["Status"].ToString()),
                    AddDate = DateTime.Parse(Dt.Rows[i]["AddDate"].ToString()),
                    Remarks = Dt.Rows[i]["Remarks"].ToString(),
                    Caid = int.Parse(Dt.Rows[i]["Caid"].ToString()),
                    Oid = int.Parse(Dt.Rows[i]["Oid"].ToString()),
                    CompanyCode = int.Parse(Dt.Rows[i]["CompanyCode"].ToString()),
                };
                payList.Add(tmp);
            }
            Db.Close();
            return payList;
        }
        public static Pay GetById(int Id)
        {
            Pay tmp = null;
            string Sql = $"Select * from T_pay Where Paid = {Id}";
            DbContext Db = new DbContext();
            DataTable Dt = Db.Execute(Sql);
            if (Dt.Rows.Count > 0)
            {
                tmp = new Pay()
                {
                    Paid = int.Parse(Dt.Rows[0]["Paid"].ToString()),
                    Padata = DateTime.Parse(Dt.Rows[0]["Padata"].ToString()),
                    PaySum = int.Parse(Dt.Rows[0]["PaySum"].ToString()),
                    Ptid = int.Parse(Dt.Rows[0]["Ptid"].ToString()),
                    Status = bool.Parse(Dt.Rows[0]["Status"].ToString()),
                    AddDate = DateTime.Parse(Dt.Rows[0]["AddDate"].ToString()),
                    Remarks = Dt.Rows[0]["Remarks"].ToString(),
                    Caid = int.Parse(Dt.Rows[0]["Caid"].ToString()),
                    Oid = int.Parse(Dt.Rows[0]["Oid"].ToString()),
                    CompanyCode = int.Parse(Dt.Rows[0]["CompanyCode"].ToString()),
                };

            }
            Db.Close();
            return tmp;
        }
        public static int DeleteById(int Id)
        {
            string Sql = $"Delete from  T_pay Where Paid = {Id}";
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