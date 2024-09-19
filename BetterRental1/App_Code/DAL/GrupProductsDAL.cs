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
    public class GrupProductsDAL
    {
        public static void Save(GrupProducts Tmp)
        {
            string Sql;
            if (Tmp.Gpid == -1)
            {
                Sql = $"insert into T_grupProducts(Gpname,ProductsId,AddDate,Remarks,Status,CompanyCode) " +
                    $"values(@Gpname,@ProductsId,@AddDate,@Remarks,@Status,@CompanyCode)";
            }
           
            else
            {
              Sql = $"Update T_grupProducts set " +
                    $"Gpname=@Gpname," +
                    $"ProductsId=@ProductsId," +
                    $"AddDate = @AddDate ," +
                    $"Remarks=@Remarks," +
                    $"Status=@Status," +
                    $"CompanyCode=@CompanyCode  Where Gpid=@Gpid";
            }
            DbContext Db = new DbContext();
            var Obj = new
            {

                Gpid = Tmp.Gpid,
                Gpname = Tmp.Gpname,
                ProductsId = Tmp.ProductsId,
                AddDate = Tmp.AddDate,
                Remarks = Tmp.Remarks,
                Status = Tmp.Status,
                CompanyCode = Tmp.CompanyCode,
            };


            var lstParam = DbContext.CreateParameters(Obj);





            Db.ExecuteNonQuery(Sql, lstParam);

            
            Db.Close();

        }
        public static List<GrupProducts> GetAll()
        {
            List<GrupProducts> GrupProductsList = new List<GrupProducts>();
            string Sql = "Select * from T_grupProducts";
            DbContext Db = new DbContext();
            DataTable Dt = Db.Execute(Sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                GrupProducts tmp = new GrupProducts()
                {
                    Gpid = int.Parse(Dt.Rows[i]["Gpid"].ToString()),
                    Gpname = Dt.Rows[i]["Gpname"].ToString(),
                    ProductsId = Dt.Rows[i]["ProductsId"].ToString(),
                    AddDate = DateTime.Parse(Dt.Rows[i]["AddDate"].ToString()),
                    Remarks = Dt.Rows[i]["Remarks"].ToString(),
                    Status = bool.Parse(Dt.Rows[i]["Status"].ToString()),
                    CompanyCode = int.Parse(Dt.Rows[i]["CompanyCode"].ToString()),
                };
                GrupProductsList.Add(tmp);
            }
            Db.Close();
            return GrupProductsList;
        }
        public static GrupProducts GetById(int Id)
        {
            GrupProducts tmp = null;
            string Sql = $"Select * from T_grupProducts Where Gpid = {Id}";
            DbContext Db = new DbContext();
            DataTable Dt = Db.Execute(Sql);
            if (Dt.Rows.Count > 0)
            {
                tmp = new GrupProducts()
                {
                    Gpid = int.Parse(Dt.Rows[0]["Gpid"].ToString()),
                    ProductsId = Dt.Rows[0]["ProductsId"].ToString(),
                    Gpname = Dt.Rows[0]["Gpname"].ToString(),
                    AddDate = DateTime.Parse(Dt.Rows[0]["AddDate"].ToString()),
                    Remarks = Dt.Rows[0]["Remarks"].ToString(),
                    Status = bool.Parse(Dt.Rows[0]["Status"].ToString()),
                    CompanyCode = int.Parse(Dt.Rows[0]["CompanyCode"].ToString()),
                };

            }
            Db.Close();
            return tmp;
        }
        public static int DeleteById(int Id)
        {
            string Sql = $"Delete from  T_grupProducts Where Gpid = {Id}";
            DbContext Db = new DbContext();
            int Total = Db.ExecuteNonQuery(Sql);
            Db.Close();
            if (Total > 0)
                return 1;
            else
                return -1;

        }
}   }