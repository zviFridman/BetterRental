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
    public class ProductDiscontGrupDAL
    {
        public static void Save(ProductDiscontGrup Tmp)
        {
            string Sql;
            if (Tmp.PDid == -1)
            {
                Sql = $"insert into T_productDiscontGrup(Gpid,Gid,AddDate,Remarks,CompanyCode,Status,Discount) " +
                    $"values(@Gpid,@Gid,@AddDate,@Remarks,@CompanyCode,@Status,@Discount)";
            }
            else
            {
                Sql = $"Update T_productDiscontGrup set " +
                    $"Gpid=@Gpid," +
                    $"Gid=@Gid," +
                     $"AddDate=@AddDate," +
                     $"Remarks=@Remarks," +
                     $"Status=@Status," +
                     $"CompanyCode=@CompanyCode," +
                   
                     $"Discount=@Discount             Where PDid=@PDid ";
            }
            DbContext Db = new DbContext();
            var Obj = new
            {

                PDid = Tmp.PDid,
                Gpid=Tmp.Gpid,
                Gid = Tmp.Gid,
                Remarks = Tmp.Remarks,
                CompanyCode = Tmp.CompanyCode,
                AddDate = Tmp.AddDate,
                Status = Tmp.Status,
                Discount=Tmp.Discount,
            };


            var lstParam = DbContext.CreateParameters(Obj);





            Db.ExecuteNonQuery(Sql, lstParam);

           
            Db.Close();

        }
        public static List<ProductDiscontGrup> GetAll()
        {
            List<ProductDiscontGrup> ProductDiscontGrupList = new List<ProductDiscontGrup>();
            string Sql = "Select * from T_productDiscontGrup";
            DbContext Db = new DbContext();
            DataTable Dt = Db.Execute(Sql);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                ProductDiscontGrup tmp = new ProductDiscontGrup()
                {
                    PDid = int.Parse(Dt.Rows[i]["PDid"].ToString()),
                    Gpid = int.Parse(Dt.Rows[i]["Gpid"].ToString()),
                    Gid = int.Parse(Dt.Rows[i]["Gid"].ToString()),
                    Status = bool.Parse(Dt.Rows[i]["Status"].ToString()),
                    Remarks = Dt.Rows[i]["Remarks"].ToString(),
                    AddDate = DateTime.Parse(Dt.Rows[i]["AddDate"].ToString()),
                    CompanyCode = int.Parse(Dt.Rows[i]["CompanyCode"].ToString()),
                    Discount = float.Parse(Dt.Rows[i]["Discount"].ToString()),

                };
                ProductDiscontGrupList.Add(tmp);
            }
            Db.Close();
            return ProductDiscontGrupList;
        }
        public static ProductDiscontGrup GetById(int Id )
        {
            ProductDiscontGrup tmp = null;
            string Sql = $"Select * from T_productDiscontGrup  Where PDid={Id}";
            DbContext Db = new DbContext();
            DataTable Dt = Db.Execute(Sql);
            if (Dt.Rows.Count > 0)
            {
                tmp = new ProductDiscontGrup()
                {
                    PDid = int.Parse(Dt.Rows[0]["PDid"].ToString()),
                    Gpid = int.Parse(Dt.Rows[0]["Gpid"].ToString()),
                    Gid = int.Parse(Dt.Rows[0]["Gid"].ToString()),
                    Status = bool.Parse(Dt.Rows[0]["Status"].ToString()),
                    Remarks = Dt.Rows[0]["Remarks"].ToString(),
                    AddDate = DateTime.Parse(Dt.Rows[0]["AddDate"].ToString()),
                    CompanyCode = int.Parse(Dt.Rows[0]["CompanyCode"].ToString()),
                    Discount = float.Parse(Dt.Rows[0]["Discount"].ToString()),

                };

            }
            Db.Close();
            return tmp;
        }
        public static int DeleteById(int Id)
        {
            string Sql = $"Delete from  T_productDiscontGrup  Where PDid={Id}";
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