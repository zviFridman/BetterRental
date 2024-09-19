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
    public class CategorysDAL
    {

        public static void Save(Categorys Tmp)
        {
            string Sql;
            if (Tmp.Cid == -1)
            {
                Sql = $"insert into T_categorys(Cname,Remarks,AddDate,Status,CompanyCode) " +
                    $"values(@Cname,@Remarks,@AddDate,@Status,@CompanyCode)";
            }
            else
            {
                Sql = $"Update T_categorys set " +
                    $"Cname=@Cname," +
                    $"Remarks=@Remarks," +
                    $"AddDate=@AddDate," +
                    $"Status = @Status," +
                    $"CompanyCode=@CompanyCode   Where Cid=@Cid";
            }
            DbContext Db = new DbContext();
            var Obj = new
            {

                Cname = Tmp.Cname,
                Cid = Tmp.Cid,
                Remarks = Tmp.Remarks,
                AddDate = Tmp.AddDate,
                Status = Tmp.Status,
                CompanyCode = Tmp.CompanyCode,
            };


            var lstParam = DbContext.CreateParameters(Obj);





            Db.ExecuteNonQuery(Sql, lstParam);

           
            Db.Close();



        }
        public static List<Categorys> GetAll()
        {
            List<Categorys> categorysList = new List<Categorys>();
            string Sql = "Select * from T_categorys";
            DbContext Db = new DbContext();
            DataTable Dt = Db.Execute(Sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Categorys tmp = new Categorys()
                {
                    Cname = Dt.Rows[i]["Cname"].ToString(),
                    Cid = int.Parse(Dt.Rows[i]["Cid"].ToString()),
                    Remarks = Dt.Rows[i]["Remarks"].ToString(),
                    AddDate = DateTime.Parse(Dt.Rows[i]["AddDate"].ToString()),
                    Status = bool.Parse(Dt.Rows[i]["Status"].ToString()),
                    CompanyCode = int.Parse(Dt.Rows[i]["CompanyCode"].ToString()),
                };
                categorysList.Add(tmp);
            }
            Db.Close();
            return categorysList;
        }
        public static Categorys GetById(int Id)
        {
            Categorys tmp = null;
            string Sql = $"Select * from T_categorys Where Cid = {Id}";
            DbContext Db = new DbContext();
            DataTable Dt = Db.Execute(Sql);
            if (Dt.Rows.Count > 0)
            {
                tmp = new Categorys()
                {

                    Cname = Dt.Rows[0]["Cname"].ToString(),
                    Cid = int.Parse(Dt.Rows[0]["Cid"].ToString()),
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
            string Sql = $"Delete from  T_categorys Where Cid = {Id}";
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