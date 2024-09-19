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
    public class CustomersDAL
    {


        public static void Save(Customers Tmp)
        {
            string Sql;
            if (Tmp.CUid == -1)
            {
                Sql = $"insert into T_customers(CUname,CUadress,CUemail,CUphone,CUtype,Money,Gid,Ltd,Payname,Oblogo,Payphone,Remarks,AddDate,Status,CompanyCode) " +
                    $"values(@CUname,@CUadress,@CUemail,@CUphone,@CUtype,@Money,@Gid,@Ltd,@Payname,@Oblogo,@Payphone,@Remarks,@AddDate,@Status,@CompanyCode)";
            }
            else
            {
                Sql = $"Update T_customers set " +
                    $"CUname=@CUname," +
                    $"CUadress=@CUadress," +
                    $"CUemail=@CUemail," +
                    $"CUphone=@CUphone," +
                    $"CUtype=@CUtype," +
                    $"Money=@Money," +
                    $"Gid=@Gid," +
                    $"Ltd=@Ltd," +
                    $"Payname=@Payname," +
                    $"Oblogo=@Oblogo," +
                    $"Payphone=@Payphone," +
                    $"Remarks=@Remarks," +
                    $"AddDate=@AddDate," +
                    $"Status = @Status,"  +
                    $"CompanyCode=@CompanyCode   Where CUid=@CUid";
            }
            DbContext Db = new DbContext();
            var Obj = new
            {
                CUname = Tmp.CUname,
                CUadress = Tmp.CUadress,
                CUemail = Tmp.CUemail,
                CUphone = Tmp.CUphone,
                CUtype = Tmp.CUtype,
                CUid = Tmp.CUid,
                Money = Tmp.Money,
                Ltd = Tmp.Ltd,
                Gid=Tmp.Gid,
                Payname = Tmp.Payname,
                Oblogo = Tmp.Oblogo,
                Payphone = Tmp.Payphone,
                Remarks = Tmp.Remarks,
                AddDate = Tmp.AddDate,
                Status = Tmp.Status,
                CompanyCode = Tmp.CompanyCode,

            };


            var lstParam = DbContext.CreateParameters(Obj);

            Db.ExecuteNonQuery(Sql, lstParam);


            
            Db.Close();



        }
        public static List<Customers> GetAll()
        {
            List<Customers> customersList = new List<Customers>();
            string Sql = "Select * from T_customers";
            DbContext Db = new DbContext();
            DataTable Dt = Db.Execute(Sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Customers tmp = new Customers()
                {
                    CUname = Dt.Rows[i]["CUname"].ToString(),
                    CUadress = Dt.Rows[i]["CUadress"].ToString(),
                    CUemail = Dt.Rows[i]["CUemail"].ToString(),
                    CUphone = Dt.Rows[i]["CUphone"].ToString(),
                    CUtype = bool.Parse(Dt.Rows[i]["CUtype"].ToString()),
                    CUid = int.Parse(Dt.Rows[i]["CUid"].ToString()),
                    Money = float.Parse(Dt.Rows[i]["Money"].ToString()),
                    Gid = int.Parse(Dt.Rows[i]["Gid"].ToString()),
                    Ltd = Dt.Rows[i]["Ltd"].ToString(),
                    Payname = Dt.Rows[i]["Payname"].ToString(),
                    Oblogo = float.Parse(Dt.Rows[i]["Oblogo"].ToString()),
                    Payphone = Dt.Rows[i]["Payphone"].ToString(),
                    Remarks = Dt.Rows[i]["Remarks"].ToString(),
                    AddDate = DateTime.Parse(Dt.Rows[i]["AddDate"].ToString()),
                    Status = bool.Parse(Dt.Rows[i]["Status"].ToString()),
                    CompanyCode = int.Parse(Dt.Rows[i]["CompanyCode"].ToString()),
                };
                customersList.Add(tmp);
            }
            Db.Close();
            return customersList;
        }
        public static Customers GetById(int Id)
        {
            Customers tmp = null;
            string Sql = $"Select * from T_customers Where CAid = {Id}";
            DbContext Db = new DbContext();
            DataTable Dt = Db.Execute(Sql);
            if (Dt.Rows.Count > 0)
            {
                tmp = new Customers()
                {
                    CUname = Dt.Rows[0]["CUname"].ToString(),
                    CUadress = Dt.Rows[0]["CUadress"].ToString(),
                    CUemail = Dt.Rows[0]["CUemail"].ToString(),
                    CUphone = Dt.Rows[0]["CUphone"].ToString(),
                    CUtype = bool.Parse(Dt.Rows[0]["CUtype"].ToString()),
                    CUid = int.Parse(Dt.Rows[0]["CUid"].ToString()),
                    Money = float.Parse(Dt.Rows[0]["Money"].ToString()),
                    Gid = int.Parse(Dt.Rows[0]["Gid"].ToString()),
                    Ltd = Dt.Rows[0]["Ltd"].ToString(),
                    Payname = Dt.Rows[0]["Payname"].ToString(),
                    Oblogo = float.Parse(Dt.Rows[0]["Oblogo"].ToString()),
                    Payphone = Dt.Rows[0]["Payphone"].ToString(),
                    Remarks = Dt.Rows[0]["Remarks"].ToString(),
                    AddDate = DateTime.Parse(Dt.Rows[0]["AddDate"].ToString()),
                    Status = bool.Parse(Dt.Rows[0]["Status"].ToString()),
                    CompanyCode = int.Parse(Dt.Rows[0]["CompanyCode"].ToString()),
                };

            }
            Db.Close();
            return tmp;
        }
        public static int DeleteById(int Id)
        {
            string Sql = $"Delete from  T_customers Where CAid = {Id}";
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