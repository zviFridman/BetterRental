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
    public class CompanyDAL
    {



        public static void Save(Company Tmp)
        {
            string Sql;
            if (Tmp.CompanyCode == -1)
            {
                Sql = $"insert into T_company(CompanyName,CompanyEmail,AddDate,Remarks,Status) " +
                    $"values(@CompanyName,@CompanyEmail,@AddDate,@Remarks,@Status)";
            }
            else
            {
              Sql = $"Update T_company set " +
                    $"CompanyName=@CompanyName," +
                    $"CompanyEmail=@CompanyEmail," +
                    $"AddDate=@AddDate," +
                    $"Remarks=@Remarks," +
                          
                    $"Status=@Status  Where CompanyCode=@CompanyCode";
            }
            DbContext Db = new DbContext();
            var Obj = new
            {
                CompanyCode = Tmp.CompanyCode,
                CompanyName = Tmp.CompanyName,
                CompanyEmail = Tmp.CompanyEmail,
                AddDate = Tmp.AddDate,
                Remarks = Tmp.Remarks,
                Status = Tmp.Status,
            };


            var lstParam = DbContext.CreateParameters(Obj);





            Db.ExecuteNonQuery(Sql, lstParam);

            
            Db.Close();

        }
        public static List<Company> GetAll()
        {
            List<Company> companyList = new List<Company>();
            string Sql = "Select * from T_company";
            DbContext Db = new DbContext();
            DataTable Dt = Db.Execute(Sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Company tmp = new Company()
                {
                    CompanyCode = int.Parse(Dt.Rows[i]["CompanyCode"].ToString()),
                    CompanyName = Dt.Rows[i]["CompanyName"].ToString(),
                    CompanyEmail = Dt.Rows[i]["CompanyEmail"].ToString(),
                    AddDate = DateTime.Parse(Dt.Rows[i]["AddDate"].ToString()),
                    Remarks = Dt.Rows[i]["Remarks"].ToString(),
                    Status = bool.Parse(Dt.Rows[i]["Status"].ToString()),

                };
                companyList.Add(tmp);
            }
            Db.Close();
            return companyList;
        }
        public static Company GetById(int Id)
        {
            Company tmp = null;
            string Sql = $"Select * from T_company Where CompanyCode = {Id}";
            DbContext Db = new DbContext();
            DataTable Dt = Db.Execute(Sql);
            if (Dt.Rows.Count > 0)
            {
                tmp = new Company()
                {

                    CompanyCode = int.Parse(Dt.Rows[0]["CompanyCode"].ToString()),
                    CompanyName = Dt.Rows[0]["CompanyName"].ToString(),
                    CompanyEmail = Dt.Rows[0]["CompanyEmail"].ToString(),
                    AddDate = DateTime.Parse(Dt.Rows[0]["AddDate"].ToString()),
                    Remarks = Dt.Rows[0]["Remarks"].ToString(),
                    Status = bool.Parse(Dt.Rows[0]["Status"].ToString()),
                };

            }
            Db.Close();
            return tmp;
        }
        public static int DeleteById(int Id)
        {
            string Sql = $"Delete from  T_company Where CompanyCode = {Id}";
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